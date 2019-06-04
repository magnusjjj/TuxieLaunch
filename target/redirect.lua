path = os.getenv("TUXIELAUNCHER_OVERLAY_DIRECTORY").."\\bin\\"
path_nobin = os.getenv("TUXIELAUNCHER_OVERLAY_DIRECTORY")
topath = os.getenv("TUXIELAUNCHER_SDK_DIRECTORY")
profile_directory = os.getenv("VProject")

--files_to_redirect = {"hammer.exe", "hammer_dll.dll", "hammer_run_map_launcher.exe", "vbsp.exe", "vrad.exe", "vrad_dll.dll", "vvis.exe", "vvis_dll.dll"}

files_to_redirect = listdirectory(path_nobin)
files_to_redirect_in_profile = {"GameConfig.txt", "CmdSeq.wc"}

print("Files to redirect: ")
for key,value in pairs(files_to_redirect) do
	files_to_redirect[key] = value:sub(#path_nobin+1)
	print(files_to_redirect[key])
end

local function starts_with(str, start)
   return str:sub(1, #start) == start
end

local function ends_with(str, ending)
   return ending == "" or str:sub(-#ending) == ending
end

function file_create(filename)
	for key,value in pairs(files_to_redirect_in_profile) do
		if ends_with(filename,value) then
			print("Profile")
			return profile_directory .. "\\" .. value
		end
	end
	
	for key,value in pairs(files_to_redirect) do
		if ends_with(filename, value) then
			return path_nobin .. value
		end
	end
	
	return filename
	
end

function file_fake_real_filename(filename)
	if starts_with(filename, path_nobin) then
		filename_relative = filename:sub(#path_nobin+1)
		return topath .. "\\" .. filename_relative
	end
	return filename
end

function registry_redirect_bad(inkey)
	if inkey == "Hammer" then
		return "HammerTuxieLauncher"
	end
	return inkey
end

function createprocess_redirect(filename)
	print("Hello")
	if starts_with(filename, topath) then
		return path_nobin .. filename:sub(#topath+1)
	end
	return filename
end