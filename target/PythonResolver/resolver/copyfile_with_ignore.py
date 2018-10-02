import os
import sys
from shutil import copyfile

num_added = 0
num_ignored_regex = 0
num_ignored_absolute = 0
num_not_found = 0

def sanitizefilename(filename):
	filename = filename.replace("/", "\\")
	if(filename[0] == '\\'):
		filename = filename[1:]
	filename = filename.lower()
	return filename

# It takes a filename to copy. It checks that the filename exists, and if so, also checks if it should be ignored.
def copyfile_local(filename):
	global args
	global rules
	global absolute_ignore
	global num_added
	global num_ignored_absolute
	global num_ignored_regex
	global num_not_found
	
	filename = sanitizefilename(filename)	
	filenameto = args.outputdir + '\\' + filename

	dirname = os.path.dirname(filenameto)
	filename_backup = filename
	filename = args.gamedir+'\\'+filename

	if os.path.exists(filename):
		#if(args.verbose):
		#	print("Adding: " + filename)
		for ignorerule in rules:
			if(ignorerule.match(filename_backup)):
				num_ignored_regex += 1
				if args.verbose:
					print("[IGNORED: Regex rule ] %s matches %s" % (filename,ignorerule))
				return
		
		#print(filenamesanitized)
		
		#sys.exit()
		
		
		
		for aignore in absolute_ignore:
			#print(filename_backup + ' ---------> ' + aignore)
			#print(aignore + '            ' + filename)
			if(filename_backup in absolute_ignore):#.endswith(aignore)):
				num_ignored_absolute += 1
				if args.verbose:
					print("[IGNORED: Absolute ignore] %s matches %s" % (filename, aignore))
					return
		
		if not os.path.exists(dirname):
		#	if args.verbose:
		#		print("Making dir" + dirname)
			os.makedirs(dirname)
		
		num_added += 1
		print("[ADDING] " + filename_backup)
		copyfile(filename, filenameto)
	else:
		num_not_found += 1
		if args.verbose:
			print("[IGNORED: File not found] " + filename)
		else:
			return