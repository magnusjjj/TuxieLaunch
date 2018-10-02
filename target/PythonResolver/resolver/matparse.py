import os
import sys
import re
import json

# ABANDON ALL HOPE YE WHO ENTER HERE
# IA IA PYTHON F'THGN


class ZeroLengthToken(Exception):
	pass	


class MatParse:
	filename = ""
	
	re_quoteable = re.compile('^"([^"]*?)"')
	re_quoteable2 = re.compile('^([^\s]*)')
	re_whitespace = re.compile('^(\s*)')
	
#	def TestRecursive(self, directory):
#		oknum = 0
#		failnum = 0
#		rootdir = os.path.dirname(os.path.realpath(directory))
#		for root, subdirs, files in os.walk(directory):
#			for file in files:
#				if file.endswith("vmt"):
#					try:
#						self.test(root + '/' + file)
#						oknum = oknum + 1
#					except Exception as e:
#						print("Hi there,", e)
#						failnum = failnum + 1
#						#raise(Exception("coooock"))
#		print("Oknum: " + str(oknum) + " Failnum: " + str(failnum) + " Percent OK: " + str(((float(oknum) / (failnum+oknum)) * 100)) + "%")
	
	deplist = []
	settings = {}
	
	def __init__(self):
		self.deplist = [] # No fucking clue why I need this? Have not needed it before? :S
	
	def removecomments(self,content):
		content2 = ""
		currquotes = 0
		currcomment = 0
		ignoretoendofline = False
		for character in content:
			if ignoretoendofline == False:
				content2 += character
				# If we have a /, with another character behind it, it aint a comment, so chill it
				if character != "/":
					currcomment = 0
				# If the current character is /, we want to know if this will comment out the rest of the characters on this line
				if character == "/":
					# Increase the comment counter if we are not in quotes
					if currquotes == 0:
						if currcomment == 0:
							currcomment = 1
						if currcomment == 1:
							# RED ALERT; ALL HANDS TO BATTLESTATIONS
							currcomment = 2
							ignoretoendofline = True
							# Remove the last character from the output
							content2 = content2[:-1]
				
				# We want to know whether or not we are in quotes. Keep track of that status.
				if character == "\"":
					if currquotes == 0:
						currquotes = 1
					else:
						currquotes = 0
			
			# If its a new line, reset
			if character == "\n":
				currquotes = 0
				currcomment = 0
				ignoretoendofline = False
		return content2
		
	def Parse(self, filename):
		self.filename = filename
		f = open(filename, "r")
		file = f.read()
		f.close()
		
		# Remove comments. This block is needed because // IN QUOTES consider it escaped. See http://pastebin.com/hy72fCb3
		
		file = self.removecomments(file)
		
		# Some lunatic started their VMT with a tab. BURN THE UNBELIEVER
		try:
			file, throwaway = self.ReadWhiteSpace(file)
		except ZeroLengthToken:
			pass
		file = self.ReadTokenValuePairs(file)
	
	def ReadTokenValuePairs(self, content):
		while True:
			if len(content) == 0:
				return
			if content[0] == '}':
				# Its the end of an object!
				# Scoot over to the next keyword
				content = content[1:]
				try:
					content, throwaway = self.ReadWhiteSpace(content)
				except ZeroLengthToken:
					pass
					#print ("End of file")
				return
			else:
				# Read the keyword
				content, keyword = self.ReadQuoteableKeyword(content)
				
				keyword = keyword.strip() # We actually need to do this. See materials\models\vehicles\lav_damaged.vmt
				
				# See materials/models/props_misc/pot-2.vmt. Sometimes people can not follow the instructions on the wiki, and thus create shit like "$envmaptint .25 .25 .25"
				# Since the vmt reader valve created gladly ignores anything it doesnt understand, it means that the following two numbers just get percieved as key = .25 value = .25
				
				keywordisnumberic = False
				try:
					float(keyword)
					keywordisnumberic = True
				except:
					pass
				
				if keyword.startswith(("!360?", "srgb?")):
					keyword = keyword[5:]
				if keyword.startswith("360?"):
					keyword = keyword[4:]
				if keyword.startswith(("!srgb?", "GPU<2?")):
					keyword = keyword[6:]
				if keyword.startswith("GPU>=2?"):
					keyword = keyword[7:]
				if keyword.startswith("SonyPS3?"):
					keyword = keyword[8:]
				if keyword.startswith("LowQualityCSM?"):
					keyword = keyword[len("LowQualityCSM?"):]
				
				keyword_settings = [{"name": keyword, "type":"anything"}]
				if (not keyword.startswith(("//", "\\\\"))) and (not keywordisnumberic):
					keyword_settings = [x for x in self.settings["materialspec"] if x["name"] == keyword.lower()]
				
				if len(keyword_settings) == 0:
					print(content)
					raise Exception(self.filename + " No such keyword: " + keyword)
					
				keyword_settings = keyword_settings[0]
				
				# Some lunatic DIDN'T USE WHITESPACE BETWEEN THEIR KEYWORDS AND VALUES. DIE.
				try:
					content, throwaway = self.ReadWhiteSpace(content)
				except ZeroLengthToken:
					pass
				
				thevalue = None
				# Its an object!
				if content[0] == '{':
					thevalue = {}
					#print("Start of object")
					# Scoot over to the next keyword
					content = content[1:]
					content, throwaway = self.ReadWhiteSpace(content)
					# Recurse
					self.ReadTokenValuePairs(content)
				else:
					# Its a quoteable keyword
					content, thevalue = self.ReadQuoteableKeyword(content)
					# Apparantly its just OK to just randomly end the file without a matching }
					try:
						content, throwaway = self.ReadWhiteSpace(content)
					except:
						if(len(content)) == 0:
							return
				
				if(keyword_settings["type"] == "stringdependency"):
					self.deplist.append(thevalue)
					
				if keyword_settings["type"] not in ("string", "stringdependency", "object", "rgb", "int", "anything"):
					print(thevalue)
					raise Exception("No such validation criteria: " + keyword)
				
				if keyword_settings["type"] == "object":
					if type(thevalue) is not dict:
						print(thevalue)
						raise Exception("Excepted object for: " + keyword)
				
				if keyword_settings["type"] in ("string", "stringdependency", "rgb", "int"):
					if type(thevalue) is dict:
						print(thevalue)
						raise Exception("Excepted string for: " + keyword)
				
	def ReadQuoteableKeyword(self, content):
		if content[0] == '"':
			#print("quoted")
			m = re.search(self.re_quoteable, content)
			if m is None:
				print(content)
				raise(Exception("Missing quotable keyword!"))
			keyword = m.group(1)
			if len(m.group(0)) == 0:
				raise(ZeroLengthToken("Zero length quoteable keyword!"))
			content = content[len(m.group(0)):]
			#print(keyword)
			return (content, keyword)
		else:
			#print("notquoted")
			m = re.search(self.re_quoteable2, content)
			if m is None:
				print(content)
				raise(Exception("Missing quotable keyword!"))
			keyword = m.group(1)
			if len(keyword) == 0:
				raise(ZeroLengthToken("Zero length quoteable keyword!"))
			content = content[len(m.group(0)):]
			#print(keyword)
			return (content, keyword)
		
	def ReadWhiteSpace(self, content):
		m = re.search(self.re_whitespace, content)
		if m is None:
			raise(Exception("Missing whitespace!"))
		keyword = m.group(1)
		if len(keyword) == 0:
			#print(content)
			raise(ZeroLengthToken("Zero length whitespace!"))
		content = content[len(m.group(0)):]
		return (content, keyword)