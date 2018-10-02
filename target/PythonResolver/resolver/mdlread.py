import struct
import functools
import itertools
import sys

# Doesnt do:
# cdmaterials
# find the proper smd
# referencing other mdls

class MdlResolver:
	@staticmethod
	def resolve(modelname, verbose):
		try:
			f = open(modelname, "rb")
		except:
			if verbose:
				#print("No such file: " + modelname)
				pass
			return
			
		if verbose:
			print("Reading model: " + modelname)
		f.seek(204)
		header = f.read(16)
		# index 0 is the number of textures, index 1 is the offset in the file where it stores the texture headers
		# index 2 is the number of texture directories, index 3 is the offset in the file where it stores the texture headers
		header = struct.unpack('iiii',header)
		
		# Scoot over
		f.seek(header[1])

		string_locs = []
		string_locs2 = []
		
		dependencies = []
		searchfolders = []

		for i in range(0,header[0]):
			whereiam = f.tell()
			header_texture = f.read(24+40)
			# Number 0 is all we really care about, the offset to the null terminated string of the model name
			header_texture = struct.unpack('iiiiiiiiiiiiiiii', header_texture)
			#print(header_texture[0],whereiam)
			string_locs.append(header_texture[0]+whereiam)

		# Stackoverflow. Neat, dumb method of reading a null terminated string. https://stackoverflow.com/questions/32774910/clean-way-to-read-a-null-terminated-c-style-string-from-a-file
		# For some reason, on a particular file (2K in size), it exploded in flames with out of memory problems. Kept for.. like.. it looks cool and its probably all my fault.
		# EDIT: Found it. A) Compared to wrong type of 0 B) Does not handle eof
		def readcstr(f):
			toeof = iter(functools.partial(f.read, 1), '')
			return ''.join(itertools.takewhile('\0'.__ne__, toeof))
		
		def readcstr_tuxie(f):
			returner = ""
			
			while True:
				character = f.read(1)
				if(len(character) == 0):
					print("MASSIVE EXCEPTION BOOGALOO, THE FILE JUST ENDED")
					sys.exit()
				if character == b'\x00':
					return returner
				else:
					returner += character.decode('latin1')
			
		for loc in string_locs:
			#print("Reading string at 0x%X" % loc)
			
			f.seek(loc)
			#sys.exit()
			#filename = readcstr(f)
			#print(filename)
			dependencies.append(readcstr_tuxie(f))

#		print(header[3], header[2])
		
		# Folders to look in
		f.seek(header[3])
		for i in range(0,header[2]):
			adress = struct.unpack('i', f.read(4))
			string_locs2.append(adress)
		for loc in string_locs2:
			f.seek(loc[0])
			searchfolders.append(readcstr_tuxie(f))
		#print("HELLO :3")
		return (dependencies, searchfolders)
	#4+4+64+4+12+12+12+12+12+12+
	#4+4+4+4+4+4+4+4+4+4+4+4+4+4