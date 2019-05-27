#pragma once
#include <Windows.h>
#include "thatluashit.h"

// That glorious lua state that everything uses ;)
extern thatluashit* lua;

// Alright! BACKUP ALL THE SYSCALL POINTERS \o/

extern HANDLE(WINAPI * TrueCreateFileA)(
	LPCSTR                lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
	);


extern DWORD(WINAPI * TrueGetModuleFileNameA)(
	HMODULE hModule,
	LPSTR   lpFilename,
	DWORD   nSize
);

extern DWORD(WINAPI * TrueGetModuleFileNameW)(
	HMODULE hModule,
	LPWSTR   lpFilename,
	DWORD   nSize
	);

extern HANDLE(WINAPI * TrueCreateFileW)(
	LPCWSTR                lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
	);

extern HANDLE(WINAPI * TrueFindFirstFileExW)(
	LPCWSTR            lpFileName,
	FINDEX_INFO_LEVELS fInfoLevelId,
	LPVOID             lpFindFileData,
	FINDEX_SEARCH_OPS  fSearchOp,
	LPVOID             lpSearchFilter,
	DWORD              dwAdditionalFlags
	);

extern BOOL(WINAPI * TrueGetFileAttributesExW)(
	LPCWSTR                lpFileName,
	GET_FILEEX_INFO_LEVELS fInfoLevelId,
	LPVOID                 lpFileInformation
	);


extern HMODULE(WINAPI * TrueLoadLibraryExW)(
	LPCWSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
	);

extern HMODULE(WINAPI * TrueLoadLibraryExA)(
	LPCSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
	);

extern LSTATUS(WINAPI * TrueRegCreateKeyExA)(
	HKEY                        hKey,
	LPCSTR                      lpSubKey,
	DWORD                       Reserved,
	LPSTR                       lpClass,
	DWORD                       dwOptions,
	REGSAM                      samDesired,
	CONST LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	PHKEY                       phkResult,
	LPDWORD                     lpdwDisposition
	);


// Aaaaaand now the redirections! :D

HANDLE WINAPI RedirectedFindFirstFileExW(
	LPCWSTR             lpFileName,
	FINDEX_INFO_LEVELS fInfoLevelId,
	LPVOID             lpFindFileData,
	FINDEX_SEARCH_OPS  fSearchOp,
	LPVOID             lpSearchFilter,
	DWORD              dwAdditionalFlags
);

HANDLE WINAPI RedirectedCreateFileA(LPCSTR lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
);

HANDLE WINAPI RedirectedCreateFileW(LPCWSTR lpFileName,
	DWORD                 dwDesiredAccess,
	DWORD                 dwShareMode,
	LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	DWORD                 dwCreationDisposition,
	DWORD                 dwFlagsAndAttributes,
	HANDLE                hTemplateFile
);

BOOL WINAPI RedirectedGetFileAttributesExW(
	LPCWSTR                lpFileName,
	GET_FILEEX_INFO_LEVELS fInfoLevelId,
	LPVOID                 lpFileInformation
	);

HMODULE WINAPI RedirectedLoadLibraryExW(
	LPCWSTR lpLibFileName,
	HANDLE  hFile,
	DWORD   dwFlags
	);

HMODULE WINAPI RedirectedLoadLibraryExA(
	LPCSTR lpLibFileName,
	HANDLE hFile,
	DWORD  dwFlags
);

DWORD WINAPI RedirectedGetModuleFileNameA(
	HMODULE hModule,
	LPSTR   lpFilename,
	DWORD   nSize
	);

DWORD WINAPI RedirectedGetModuleFileNameW(
	HMODULE hModule,
	LPWSTR   lpFilename,
	DWORD   nSize
	);

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
	);