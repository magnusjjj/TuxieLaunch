path = os.getenv("TUXIELAUNCHER_OVERLAY_DIRECTORY").."\\bin\\"
path_nobin = os.getenv("TUXIELAUNCHER_OVERLAY_DIRECTORY")
topath = os.getenv("TUXIELAUNCHER_SDK_DIRECTORY")
profile_directory = os.getenv("VProject")

--files_to_redirect = {"hammer.exe", "hammer_dll.dll", "hammer_run_map_launcher.exe", "vbsp.exe", "vrad.exe", "vrad_dll.dll", "vvis.exe", "vvis_dll.dll"}

files_to_redirect = listdirectory(path_nobin)
files_to_redirect_in_profile = {"GameConfig.txt", "CmdSeq.wc"}

print("Files to redirect: ")
for key,value in pairs(files_to_redirect) do
	print(value)
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

	--[[
	-- Check if any of the files match our list of files to redirect
	for key,value in pairs(files_to_redirect) do
		if ends_with(filename,value) then
			print("SIMPLE")
			return path_nobin .. "\\" .. value
		end
	end
	

	-- *sometimes* we get a request for a /bin directory, and sometimes not. I think it depends on the syscall. Dirty hack here.
    if starts_with(filename, path) then
		-- Here we go. This is a call to find a file in *our* part of town
		print("STRANGE PATH")
		

		
		-- Return an edited filename
		return topath .. "bin\\" .. filename:sub(#path+1)
	end
	--]]

	
    if starts_with(filename, path_nobin) then

		-- Here we go. This is a call to find a file in *our* part of town
		
		--[[
		-- Check if any of the files match our list of files to redirect
		for key,value in pairs(files_to_redirect) do
			if ends_with(filename,value) then
				print("SIMPLE 2")
				return filename
			end
		end
		--]]
		--print(filename:sub(#path_nobin+1))
		-- Return an edited filename
		print("COMPLEX")
		return topath .. "\\" .. filename:sub(#path_nobin+1)
    else
        return filename
    end
end

function registry_redirect_bad(inkey)
	if inkey == "Hammer" then
		return "HammerTuxieLauncher"
	end
	return inkey
end