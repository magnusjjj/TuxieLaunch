# Todo:
# Better verbose
# Cleanup
# Pause
# Check those exceptionthingys.
# Make list of files to copy
# Make a counter about how many things was ignored, and copied.
# --nomodels actually working


import re
import os
import sys
import argparse
import traceback
import shutil

# Here, we check what command line options we are supplied.

parser = argparse.ArgumentParser(description='Utility to take a vmf file, find all of the dependencies, and copy them to a directory')
parser.add_argument('--config', help='The path to the config file. Defaults to the file in the root resolver directory.', default='../config.json')
parser.add_argument('--gamedir', required=True, help='Sets the path to the game directory. Set to $gamedir in hammer :)')
parser.add_argument('--verbose', type=int, help='Sets the amount of verbosity (how much is written to the console. 1-9)', default=0)
parser.add_argument('--nomaterials', action='store_true', help='Skips copying normal materials and overlays', default=False)
parser.add_argument('--nodecals', action='store_true', help='Skips copying decals', default=False)
parser.add_argument('--nomodels', action='store_true', help='Skips copying models. Not implemented', default=False)
parser.add_argument('--pause', action='store_true', help='Pause at the end of running', default=False)
parser.add_argument('--delete', action='store_true', help='Delete target directory before running. DANGER WILL ROBINSON, if you fuck up your includes directory path...', default=False)
parser.add_argument('--ignorevmterrors', action='store_true', help='Ignores errors in material files, apart from printing the errors.', default=False)
parser.add_argument('mapfile', type=argparse.FileType('r'))
parser.add_argument('outputdir')

try:
	args = parser.parse_args()
except:
	# If something is wrong, pause, and let the user know. The nice message is for Yashimare.
	print("\nPausing. Can't help this, since its a command line parsing error :). If you are in compilepal, you have to kill it in the task manager.")
	input()
	sys.exit()

# We need to change the current working directory, so we can read the settings file and local classes. This needs to go before the inclusion of local packages.
abspath = os.path.abspath(__file__)
dname = os.path.dirname(abspath)
os.chdir(dname)
sys.path.append(dname)

if args.delete:
	try:
		shutil.rmtree(args.outputdir)
	except:
		traceback.print_exc(file=sys.stdout)

from matparse import *
from mdlread import *
import copyfile_with_ignore
from copyfile_with_ignore import *

copyfile_with_ignore.args = args

# Read settings
f = open(args.config, "r")
settings = json.loads(f.read())
f.close()
f = None

# In the settings, there is a list of rules with regular expressions, to match things we want to ignore. Largely unused, but useful.
rules = []
for ignorerule in settings["ignorelist"]:
	rules.append(re.compile(ignorerule))
copyfile_with_ignore.rules = rules

# Here we load a list of absolute paths to ignore. Because Yash is an idiot, and has extracted a metric dickton of random counter strike models into his model directory.
f = open("../resolver_list.txt", "r") # r for reade
absolute_ignore = f.readlines() # read all the lines, into a handy list
f.close()
f = None

# Thank god for stack overflow for this beauty, I usually hate these hacks but this just loops through each line and .strip()'s them to remove whitespace
absolute_ignore = [x.strip().replace("/", "\\").lower() for x in absolute_ignore]
absolute_ignore = dict((k,2) for k in absolute_ignore)
copyfile_with_ignore.absolute_ignore = absolute_ignore




# Read the map file. Time to do some work :).
content = args.mapfile.read()
args.mapfile.close()



# In this section, we start to find a list of dependencies, via gratuitous use of bad regex.

# Do the dirtiest hack in the history of mankind, and find the 'material' definitions.
# Returns a simple python list with strings.

materials = []

# Materials and decals
if not args.nomaterials:
	materials = re.findall("\"material\" \"([^\"]*)\"",content)
	# Skybox
	skybox = re.findall("\"skyname\" \"([^\"]*)\"",content)
	materials.append('skybox/'+skybox[0]+'bk')
	materials.append('skybox/'+skybox[0]+'dn')
	materials.append('skybox/'+skybox[0]+'ft')
	materials.append('skybox/'+skybox[0]+'lf')
	materials.append('skybox/'+skybox[0]+'rt')
	materials.append('skybox/'+skybox[0]+'up')

decals = re.findall("\"texture\" \"([^\"]*)\"",content)

if not args.nodecals:
	materials += decals
	

# Todo, add ignore for sound and models
models = re.findall("\"model\" \"([^\"]*)\"",content)
sounds = re.findall("\"message\" \"([^\"]*)\"",content)
sounds += re.findall("AddOutput,message ([^,]*)",content)


# Really cool hack to remove any duplicates :)
materials = list(set(materials))
models = list(set(models))
sounds = list(set(sounds))

if args.verbose > 3 and not (args.nomaterials and args.nodecals):
	print("Found these vmt dependencies when parsing:")
	print(repr(materials))
	print("Found these model dependencies when parsing:")
	print(repr(models))
	print("Found these sound dependencies when parsing (These also list 'messages', because couldnt be arsed making the distinction):")
	print(repr(sounds))


deplist = []

# Loop through the materials, find vtf's
for material in materials:
	filename = args.gamedir+'/materials/'+material+'.vmt'
	if os.path.exists(filename):
		# Hey, we found ourselves a material file, lets parse it
		mp = MatParse()
		mp.settings = settings
		try:
			mp.Parse(filename)
		except:
			# Sometimes we find a new type of variable in the VMT. We stop, and give a massive warning, so as not to miss a new type of dependency.
			print("\n\n\n[VMT ERROR]\n\nCaught an error handling the parsing of a VMT (a material file).")
			traceback.print_exc(file=sys.stdout)
			if not args.ignorevmterrors:
				print("Stopping. You can make the resolver ignore this error, and continue on, by supplying the command line parameter --ignorevmterrors")
				if args.pause:
					print("Pausing")
					input()
				sys.exit()
		deplist += mp.deplist
	else:
		if args.verbose:
			print("File does not exist: %s" % filename)


# Delete duplicates again
deplist = list(set(deplist))


if args.verbose > 3:
	print("They depend on these vtf's")
	print(deplist)


filelist = []

for material in materials:
	filelist.append('materials/'+material + '.vmt')

for vtf in deplist:
	filelist.append('materials/'+ vtf + '.vtf')
	
for sound in sounds:
	filename = '/sound/'+sound
	filelist.append(filename)

# We need to parse models. Yay.
	
deplist_models = []
for model in models:
	#deplist_models.append('/../'+model)
	mdlwithoutmdl = os.path.splitext(model)[0]
	if args.verbose > 5:
		print("Parsing: " + mdlwithoutmdl)
	
	# Are there more dependencies?
	filelist.append(mdlwithoutmdl+'.vvd')
	filelist.append(mdlwithoutmdl+'.sw.vtx')
	filelist.append(mdlwithoutmdl+'.phy')
	filelist.append(mdlwithoutmdl+'.mdl')
	filelist.append(mdlwithoutmdl+'.dx90.vtx')
	filelist.append(mdlwithoutmdl+'.dx80.vtx')
	mdldepstuff = MdlResolver.resolve(args.gamedir+'/'+model, args.verbose)
	if mdldepstuff is not None:
		materials_model = mdldepstuff[0]
		folders = mdldepstuff[1]
#		print(materials_model, folders)
		
		for folder in folders:
			#print("Checking folder " + folder)
			for material2 in materials_model:
				filename = args.gamedir+'/materials/'+folder+'/'+material2+'.vmt'
				if os.path.exists(filename):
#					print("Found the material!")
					filelist.append(folder+'/'+material2 +'.vmt')
					mp = MatParse()
					mp.settings = settings
					#mp.deplist = []
					try:
						mp.Parse(filename)
					except:
						print("\n\n\n[VMT ERROR]\n\nCaught an error handling the parsing of a VMT (a material file).")
						traceback.print_exc(file=sys.stdout)
						if not args.ignorevmterrors:
							print("Stopping. You can make the resolver ignore this error, and continue on, by supplying the command line parameter --ignorevmterrors")
							sys.exit()
						
					for vtf_model in mp.deplist:
						filelist.append('/materials/'+vtf_model+'.vtf')
				else:
					if args.verbose > 5:
						print('Could not find material file to parse' + filename)
if(args.verbose):
	print("Starting copying")

for file in filelist:
	#print("Yoloswag")
	copyfile_local(file)

print("Added: %i Ignored because of regex: %i Ignored because of absolute ignore: %i Not found: %i" % 
	(copyfile_with_ignore.num_added,copyfile_with_ignore.num_ignored_regex, copyfile_with_ignore.num_ignored_absolute, copyfile_with_ignore.num_not_found)
	)
	
if args.pause:
	print("\nPausing")
	input()
	sys.exit()