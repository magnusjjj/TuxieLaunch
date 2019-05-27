#include "APIMove.h"
#include "debugliar.h"

HANDLE(WINAPI * TrueCreateFileA)(
	LPCSTR                lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
	) = CreateFileA;

HANDLE(WINAPI * TrueCreateFileW)(
	LPCWSTR                lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
	) = CreateFileW;

HANDLE(WINAPI * TrueFindFirstFileExW)(
	LPCWSTR            lpFileName,
	FINDEX_INFO_LEVELS fInfoLevelId,
	LPVOID             lpFindFileData,
	FINDEX_SEARCH_OPS  fSearchOp,
	LPVOID             lpSearchFilter,
	DWORD              dwAdditionalFlags
	) = FindFirstFileExW;

BOOL(WINAPI * TrueGetFileAttributesExW)(
	LPCWSTR                lpFileName,
	GET_FILEEX_INFO_LEVELS fInfoLevelId,
	LPVOID                 lpFileInformation
) = GetFileAttributesExW;

HMODULE(WINAPI * TrueLoadLibraryExW)(
	LPCWSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
) = LoadLibraryExW;

HMODULE(WINAPI * TrueLoadLibraryExA)(
	LPCSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
	) = LoadLibraryExA;

DWORD(WINAPI * TrueGetModuleFileNameA)(
	HMODULE hModule,
	LPSTR   lpFilename,
	DWORD   nSize
	) = GetModuleFileNameA;

DWORD(WINAPI * TrueGetModuleFileNameW)(
	HMODULE hModule,
	LPWSTR   lpFilename,
	DWORD   nSize
	) = GetModuleFileNameW;

LSTATUS(WINAPI * TrueRegCreateKeyExA)(
	HKEY                        hKey,
	LPCSTR                      lpSubKey,
	DWORD                       Reserved,
	LPSTR                       lpClass,
	DWORD                       dwOptions,
	REGSAM                      samDesired,
	CONST LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	PHKEY                       phkResult,
	LPDWORD                     lpdwDisposition
	) = RegCreateKeyExA;



// Aw yiiiis, lets have some actual handlers all up in this bznzzzzz

HANDLE WINAPI RedirectedFindFirstFileExW(
	LPCWSTR             lpFileName,
	FINDEX_INFO_LEVELS fInfoLevelId,
	LPVOID             lpFindFileData,
	FINDEX_SEARCH_OPS  fSearchOp,
	LPVOID             lpSearchFilter,
	DWORD              dwAdditionalFlags
)
{
	LIAR_DEBUG_INTRICATE("In findfirstfileexw: %ls\n", lpFileName);
	// Lock lua! Be nice!
	lua->getLock();
	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	lua->pushlpcwstr(lpFileName);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	// Get what's returned
	LPCWSTR filenameredirected = lua->poplpcwstr();
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();

	// Call the *original* filesystem call
	HANDLE ret = TrueFindFirstFileExW(
		filenameredirected,
		fInfoLevelId,
		lpFindFileData,
		fSearchOp,
		lpSearchFilter,
		dwAdditionalFlags
	);

	LIAR_DEBUG("findfirstfileexw, inname: %ls outname: %ls Handle: %x\n", lpFileName, filenameredirected, (unsigned int)ret);

	// Cleanup
	free((void *)filenameredirected);
	return ret;
}

HANDLE WINAPI RedirectedCreateFileA(LPCSTR                lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
) {
	//printf("In createfilea\n");
	//
	// Lock lua! Be nice!
	LIAR_DEBUG_INTRICATE("In createfilea: %s\n", lpFileName);
	lua->getLock();
	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	lua->pushlpcstr(lpFileName);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	// Get what's returned
	LPCSTR filenameredirected = lua->poplpcstr();
	LIAR_DEBUG_INTRICATE("In createfilea, lua returned: %s\n", filenameredirected);
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	LIAR_DEBUG_INTRICATE("In createfilea, released lock\n");
	// Call the *original* filesystem call
	HANDLE ret = TrueCreateFileA(filenameredirected, dwDesiredAccess, dwShareMode, lpSecurityAttributes, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile);
	// Cleanup
	free((void *)filenameredirected);
	LIAR_DEBUG("In redirectedcreatefilea, infile: %s outfile: %s handle %x\n", lpFileName, filenameredirected, (unsigned int)ret);
	return ret;
}

HANDLE WINAPI RedirectedCreateFileW(LPCWSTR                lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
) {
	LIAR_DEBUG_INTRICATE("In createfilew: %ls\n", lpFileName);
	
	// Lock lua! Be nice!
	lua->getLock();
	LIAR_DEBUG_INTRICATE("Got lock\n");
	
	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	LIAR_DEBUG_INTRICATE("In before execute\n");
	//
	lua->pushlpcwstr(lpFileName);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	LIAR_DEBUG_INTRICATE("post execute\n");
	
	// Get what's returned
	LPCWSTR filenameredirected = lua->poplpcwstr();
	LIAR_DEBUG_INTRICATE("lua returned: %ls\n", filenameredirected);
	
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	//printf("Calling the original function\n");
	//
	// Call the *original* filesystem call
	HANDLE ret = TrueCreateFileW(filenameredirected, dwDesiredAccess, dwShareMode, lpSecurityAttributes, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile);
	LIAR_DEBUG("In redirectedcreatefilew infile: %ls outfile: %ls Handle: %x\n", lpFileName, filenameredirected, (unsigned int)ret);
	// Cleanup
	free((void *)filenameredirected);
	return ret;
}

BOOL WINAPI  RedirectedGetFileAttributesExW(LPCWSTR                lpFileName,
	GET_FILEEX_INFO_LEVELS fInfoLevelId,
	LPVOID                 lpFileInformation
) {
	LIAR_DEBUG_INTRICATE("In RedirectedGetFileAttributesExW: %ls\n", lpFileName);
	
	// Lock lua! Be nice!
	lua->getLock();
	LIAR_DEBUG_INTRICATE("Got lock\n");
	
	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	LIAR_DEBUG_INTRICATE("In before execute\n");
	//
	lua->pushlpcwstr(lpFileName);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	LIAR_DEBUG_INTRICATE("post execute\n");
	
	// Get what's returned
	LPCWSTR filenameredirected = lua->poplpcwstr();
	LIAR_DEBUG_INTRICATE("lua returned: %ls\n", filenameredirected);
	
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	//printf("Calling the original function\n");
	//
	// Call the *original* filesystem call
	BOOL ret = TrueGetFileAttributesExW(filenameredirected, fInfoLevelId, lpFileInformation);
	LIAR_DEBUG("In RedirectedGetFileAttributesExW: infile: %ls outfile: %ls Status: %s\n", lpFileName, filenameredirected, ret ? "true" : "false");
	;
	// Cleanup
	free((void *)filenameredirected);
	return ret;
}

HMODULE WINAPI  RedirectedLoadLibraryExW(
	LPCWSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
) {
	LIAR_DEBUG_INTRICATE("In RedirectedLoadLibraryExW: %ls\n", lpLibFileName);

	// Lock lua! Be nice!
	lua->getLock();
	LIAR_DEBUG_INTRICATE("Got lock\n");

	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	LIAR_DEBUG_INTRICATE("In before execute\n");
	//
	lua->pushlpcwstr(lpLibFileName);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	LIAR_DEBUG_INTRICATE("post execute\n");
	
	// Get what's returned
	LPCWSTR filenameredirected = lua->poplpcwstr();
	LIAR_DEBUG_INTRICATE("lua returned: %ls\n", filenameredirected);
	
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	//printf("Calling the original function\n");
	//
	// Call the *original* filesystem call
	HMODULE ret = TrueLoadLibraryExW(filenameredirected, hFile, dwFlags);
	LIAR_DEBUG("In redirectedloadlibraryexw infile: %ls outfile: %ls Handle: %x\n", lpLibFileName, filenameredirected, (unsigned int)ret);

	//printf("Status: %s\n", ret ? "true" : "false");
	//
	// Cleanup
	free((void *)filenameredirected);
	return ret;
}

HMODULE WINAPI  RedirectedLoadLibraryExA(
	LPCSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
) {
	//printf("In createfilea\n");
	//
	// Lock lua! Be nice!
	LIAR_DEBUG_INTRICATE("In RedirectedLoadLibraryExA: %s\n", lpLibFileName);
	
	lua->getLock();
	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	lua->pushlpcstr(lpLibFileName);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	// Get what's returned
	LPCSTR filenameredirected = lua->poplpcstr();
	LIAR_DEBUG_INTRICATE("In RedirectedLoadLibraryExA, lua returned: %s\n", filenameredirected);
	
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	LIAR_DEBUG_INTRICATE("In RedirectedLoadLibraryExA, released lock\n");
	// Call the *original* filesystem call
	HMODULE ret = TrueLoadLibraryExA(filenameredirected, hFile, dwFlags);
	// Cleanup
	free((void *)filenameredirected);
	LIAR_DEBUG_INTRICATE("Done in redirectedloadlibraryexa\n");
	LIAR_DEBUG("In redirectedloadlibraryexa infile: %s outfile: %s Handle: %x\n", lpLibFileName, filenameredirected, (unsigned int)ret);
	return ret;
}

// Todo: Error handling. Right now we expect everything to just work. That's naive, there could be some buffer overflow shizzle.
DWORD WINAPI RedirectedGetModuleFileNameA(HMODULE hModule,
	LPSTR   lpFilename,
	DWORD   nSize
) {

	// In this function we will have to do things backwards. Call the *real* function first, *then* redirect
	DWORD ret = TrueGetModuleFileNameA(hModule, lpFilename, nSize);
	LIAR_DEBUG_INTRICATE("In TrueGetModuleFileNameA, returned module filename was %s\n", lpFilename);
	// Lock lua! Be nice!
	lua->getLock();
	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	lua->pushlpcstr(lpFilename);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	// Get what's returned
	LPCSTR filenameredirected = lua->poplpcstr();
	LIAR_DEBUG_INTRICATE("In TrueGetModuleFileNameA, lua returned: %s\n", filenameredirected);
	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	LIAR_DEBUG_INTRICATE("In TrueGetModuleFileNameA, released lock\n");

	LIAR_DEBUG("In TrueGetModuleFileNameA, infile: %s outfile: %s length: %i\n", lpFilename, filenameredirected, (unsigned int)ret);
	// Alright. Lets copy that new filename
	strcpy_s(lpFilename, nSize, filenameredirected);

	// Cleanup
	free((void *)filenameredirected);
	
	return strlen(filenameredirected);
}

DWORD WINAPI RedirectedGetModuleFileNameW(HMODULE hModule,
	LPWSTR   lpwFilename,
	DWORD   nSize
) {

	DWORD ret = TrueGetModuleFileNameW(hModule, lpwFilename, nSize);
	LIAR_DEBUG_INTRICATE("In TrueGetModuleFileNameW, returned module filename was %ls\n", lpwFilename);
	return ret;
	
	LIAR_DEBUG_INTRICATE("In createfilew: %ls\n", lpFileName);

	// Lock lua! Be nice!
	lua->getLock();
	LIAR_DEBUG_INTRICATE("Got lock\n");

	// Set the function name we want to call!
	lua->setFunctionName("file_create");
	// Push the filename someone tried to access
	LIAR_DEBUG_INTRICATE("In before execute\n");
	//
	lua->pushlpcwstr(lpwFilename);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	LIAR_DEBUG_INTRICATE("post execute\n");

	// Get what's returned
	LPCWSTR filenameredirected = lua->poplpcwstr();
	LIAR_DEBUG_INTRICATE("lua returned: %ls\n", filenameredirected);

	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();

	LIAR_DEBUG("In TrueGetModuleFileNameW, infile: %ls outfile: %ls length: %i\n", lpwFilename, filenameredirected, (unsigned int)ret);
	wcscpy_s(lpwFilename, nSize, filenameredirected);

	// Cleanup
	free((void *)filenameredirected);
	return ret;
	
}

LSTATUS WINAPI RedirectedRegCreateKeyExA(
	HKEY                        hKey,
	LPCSTR                      lpSubKey,
	DWORD                       Reserved,
	LPSTR                       lpClass,
	DWORD                       dwOptions,
	REGSAM                      samDesired,
	CONST LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	PHKEY                       phkResult,
	LPDWORD                     lpdwDisposition
) {
	//printf("In createfilea\n");
	//
	// Lock lua! Be nice!
	LIAR_DEBUG_INTRICATE("In RedirectedRegCreateKeyExA: %s\n", lpLibFileName);

	lua->getLock();
	// Set the function name we want to call!
	lua->setFunctionName("registry_redirect_bad");
	// Push the filename someone tried to access
	lua->pushlpcstr(lpSubKey);
	// BAM! Call that!
	lua->executeFunction(1, 1);
	// Get what's returned
	LPCSTR keyredirected = lua->poplpcstr();
	LIAR_DEBUG_INTRICATE("In RedirectedRegCreateKeyExA, lua returned: %s\n", keyredirected);

	// Releeeeasee meeeee, please don't keep me down
	lua->releaseLock();
	LIAR_DEBUG_INTRICATE("In RedirectedRegCreateKeyExA, released lock\n");
	// Call the *original* filesystem call
	LSTATUS ret = TrueRegCreateKeyExA(hKey, keyredirected, Reserved, lpClass, dwOptions, samDesired, lpSecurityAttributes, phkResult, lpdwDisposition);
	// Cleanup
	free((void *)keyredirected);
	LIAR_DEBUG_INTRICATE("Done in RedirectedRegCreateKeyExA\n");
	LIAR_DEBUG("In RedirectedRegCreateKeyExA inkey: %s outkey: %s lstatus: %x\n", lpSubKey, keyredirected, ret);
	return ret;
}