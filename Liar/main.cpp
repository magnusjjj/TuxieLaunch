//////////////////////////////////////////////////////////////////////////////
//
//  Detours liar package. Written by Magnus Johnsson, licensed under the MIT license

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <windows.h>
#include "detours.h"
#include <string>
#include "APIMove.h"
#include "thatluashit.h"
#include "main.h"


//#pragma warning( disable : 4996;)

EXTERN_C IMAGE_DOS_HEADER __ImageBase;

// Welcome, guys, gals, everything inbetween and outside, to the entrypoint of liar!

BOOL WINAPI DllMain(HINSTANCE hinst, DWORD dwReason, LPVOID reserved)
{
	// Just some variables for.. error handling? From the sample.
	LONG error;
	(void)hinst;
	(void)reserved;
	


	if (dwReason == DLL_PROCESS_ATTACH) {

		// Alright! Here we go! First, initialize detours, the library that does syscall redirection
		DetourRestoreAfterWith();

		char path[MAX_PATH];
		char exepath[MAX_PATH] = "";

		printf("liar" DETOURS_STRINGIFY(DETOURS_BITS) ".dll:"
			" Starting.\n");

		char pathout[MAX_PATH] = "";
		char patherr[MAX_PATH] = "";
		char pathscript[MAX_PATH] = "";
		

		HMODULE hm = NULL;

		if (DetourIsHelperProcess()) {
			return TRUE;
		}


		GetModuleFileName((HINSTANCE)&__ImageBase, path, _countof(path));
		GetModuleFileName(NULL, exepath, _countof(exepath));
		printf("Exe name: %s\n", exepath);

		char path_buffer[_MAX_PATH];
		char drive[_MAX_DRIVE];
		char dir[_MAX_DIR];
		char fname[_MAX_FNAME];
		char ext[_MAX_EXT];

		char path_buffer_exe[_MAX_PATH];
		char drive_exe[_MAX_DRIVE];
		char dir_exe[_MAX_DIR];
		char fname_exe[_MAX_FNAME];
		char ext_exe[_MAX_EXT];

		_splitpath(path, drive, dir, fname, ext);
		_splitpath(exepath, drive_exe, dir_exe, fname_exe, ext_exe);
		printf("Exe name: %s drive: %s dir_exe: %s fname_exe: %s ext_exe: %s\n", exepath, drive_exe, dir_exe, fname_exe, ext_exe);

		std::string logpath = "";
		std::string errorlogpath = "";

		logpath = logpath + drive + "\\" + dir + fname_exe + "_log.txt";

		printf("Log file path: %s", logpath.c_str());

		strcpy(path_buffer_exe, fname_exe);
		strcpy(path_buffer_exe, "log.txt");

		strcpy(path_buffer, drive);
		strcat(path_buffer, "\\");
		strcat(path_buffer, dir);

		strcpy(pathout, path_buffer);
		strcat(pathout, path_buffer_exe);

		strcpy(patherr, path_buffer);
		strcpy(patherr, fname_exe);
		strcpy(patherr, "log_err.txt");

		strcpy(pathscript, drive);
		strcat(pathscript, "\\");
		strcat(pathscript, dir);
		strcat(pathscript, "redirect.lua");

		// Next up, redirect stdout and stderr. You can uncomment these if your program is a shell application. Otherwise, uh. Confusion?
		freopen(logpath.c_str(), "w", stdout);
		freopen(patherr, "w", stderr);



		printf("liar" DETOURS_STRINGIFY(DETOURS_BITS) ".dll:"
			" Starting in %s\n", pathout);
		fflush(stdout); // Forces a flush to the file, so we know it hasn't just stalled.


		// Time to tell detours to get going.
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());

		// Next up, read the lua file!
		lua = new thatluashit(); // Wait, what, this is really it?
		lua->pushpathlist("files_to_redirect", path_buffer);
		// That feeling when you realize that it's actually built into lua:
		//lua->pushenv("env");
		lua->runfile(pathscript);


		
	//	fflush(stdout); //F-f-f-f-lush
	//	fflush(stderr);
		// Finally! We redirect all those sweet, sweet syscalls. Up and at them!
		// First argument is the syscall we want to redirect, second is where it redirects *to*
		DetourAttach(&(PVOID&)TrueCreateFileA, RedirectedCreateFileA);
		DetourAttach(&(PVOID&)TrueCreateFileW, RedirectedCreateFileW);
		DetourAttach(&(PVOID&)TrueFindFirstFileExW, RedirectedFindFirstFileExW);
		DetourAttach(&(PVOID&)TrueGetFileAttributesExW, RedirectedGetFileAttributesExW);
		DetourAttach(&(PVOID&)TrueLoadLibraryExW, RedirectedLoadLibraryExW);
		DetourAttach(&(PVOID&)TrueLoadLibraryExA, RedirectedLoadLibraryExA);
		DetourAttach(&(PVOID&)TrueGetModuleFileNameW, RedirectedGetModuleFileNameW);
		DetourAttach(&(PVOID&)TrueGetModuleFileNameA, RedirectedGetModuleFileNameA);
		DetourAttach(&(PVOID&)TrueRegCreateKeyExA, RedirectedRegCreateKeyExA);
		DetourAttach(&(PVOID&)TrueCreateProcessA, RedirectedCreateProcessA);
		DetourAttach(&(PVOID&)TrueCreateProcessW, RedirectedCreateProcessW);

		error = DetourTransactionCommit();

		if (error == NO_ERROR) {
			printf("liar" DETOURS_STRINGIFY(DETOURS_BITS) ".dll:"
				" No errors\n");
		}
		else {
			printf("liar" DETOURS_STRINGIFY(DETOURS_BITS) ".dll:"
				" Detour error: %d\n", error);
		}
	}
	else if (dwReason == DLL_PROCESS_DETACH) {
		// Cleanup stuff.
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());
		DetourDetach(&(PVOID&)TrueCreateFileA, RedirectedCreateFileA);
		DetourDetach(&(PVOID&)TrueCreateFileW, RedirectedCreateFileW);
		DetourDetach(&(PVOID&)TrueFindFirstFileExW, RedirectedFindFirstFileExW);
		DetourDetach(&(PVOID&)TrueGetFileAttributesExW, RedirectedGetFileAttributesExW);
		DetourDetach(&(PVOID&)TrueLoadLibraryExW, RedirectedLoadLibraryExW);
		DetourDetach(&(PVOID&)TrueLoadLibraryExA, RedirectedLoadLibraryExA);
		DetourDetach(&(PVOID&)TrueLoadLibraryExW, RedirectedLoadLibraryExW);
		DetourDetach(&(PVOID&)TrueLoadLibraryExA, RedirectedLoadLibraryExA);
		DetourDetach(&(PVOID&)TrueGetModuleFileNameW, RedirectedGetModuleFileNameW);
		DetourDetach(&(PVOID&)TrueGetModuleFileNameA, RedirectedGetModuleFileNameA);
		DetourDetach(&(PVOID&)TrueRegCreateKeyExA, RedirectedRegCreateKeyExA);
		DetourDetach(&(PVOID&)TrueCreateProcessA, RedirectedCreateProcessA);
		DetourDetach(&(PVOID&)TrueCreateProcessW, RedirectedCreateProcessW);
		error = DetourTransactionCommit();

		fflush(stdout);
	}
	return TRUE;
}

//
///////////////////////////////////////////////////////////////// End of File.
