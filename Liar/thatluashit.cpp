#include "thatluashit.h"
#include "debugliar.h"
extern "C" {
#include <luajit.h>
}

#include <filesystem>
#include "getenv.h"
#include <Windows.h>
#include <stdarg.h>

namespace fs = std::experimental::filesystem;
static int l_getdirectory(lua_State *L);

#pragma warning(disable:4996)

// This is the file where we are doing all the lua shit. Surprise.
thatluashit* lua;

thatluashit::thatluashit()
{
	// Start up lua
	this->L = luaL_newstate();
	luaJIT_setmode(L, 0, LUAJIT_MODE_ENGINE | LUAJIT_MODE_OFF);
	luaL_openlibs(this->L);
	lua_pushcfunction(this->L, l_getdirectory);
	lua_setglobal(this->L, "listdirectory");

	// Create the locking mechanism :3
	this->hLuaMutex = CreateMutex(NULL, FALSE, NULL);
}




thatluashit::~thatluashit()
{
	// Clean up!
	lua_close(L);
	CloseHandle(this->hLuaMutex);
}

void thatluashit::runfile(const char* filename)
{
	// Run the file
	int error = luaL_dofile(this->L, filename);
	// Todo: Better errors :P
	if (error) {
		LIAR_DEBUG("Error in lua init!");
	}
}

// The name says it all really <3
void thatluashit::setFunctionName(const char* function_name) {
	lua_getglobal(L, function_name);
}

// Run a lua function
void thatluashit::executeFunction(int argumentnumber, int returnnumber) {
	//printf("lua: ");
	if (lua_pcall(this->L, argumentnumber, returnnumber, 0))
	{
		printf("error running function: %s", lua_tostring(L, -1));
	}

	fflush(stdout); //F-f-f-f-lush
	fflush(stderr);
}

// Push a wide string to the stack
// *deep breath* This entire thing? 90% UNICODE BULLSHITRY
void thatluashit::pushlpcwstr(LPCWSTR str) {
	LIAR_DEBUG_INTRICATE("c lpcwstr: %ls\n", str);
	//fflush(stdout);
	size_t len = wcslen(str);
	size_t maxUtf8len = 4 * len + 1;
	char *utf8string = new char[maxUtf8len];
	WideCharToMultiByte(CP_UTF8, 0, str, len + 1, utf8string, maxUtf8len, NULL, NULL);
	lua_pushstring(this->L, utf8string);
	delete[] utf8string;
}

// Pop a wide string off the stack
// *deep breath* This entire thing? 90% UNICODE BULLSHITRY
LPCWSTR thatluashit::poplpcwstr() {
	const char* instr = lua_tostring(L, -1);
	LIAR_DEBUG_INTRICATE("Returned from lua: %s\n", instr);
	//fflush(stdout);
	char* my_copy = (char*)malloc(strlen(instr) + 1);
	strcpy(my_copy, instr);

	lua_pop(this->L, 1);
	//MultiByteToWideChar(CP_UTF8, 0, my_copy, strlen(instr)+1, )


	int wchars_num = MultiByteToWideChar(CP_UTF8, 0, my_copy, -1, NULL, 0);
	wchar_t* wstr = new wchar_t[wchars_num];
	MultiByteToWideChar(CP_UTF8, 0, my_copy, -1, wstr, wchars_num);
	free(my_copy);
	return wstr;
}

// Push a string to the stack
void thatluashit::pushlpcstr(LPCSTR str) {
	LIAR_DEBUG_INTRICATE("c lpcstr: %s\n",str);
	//fflush(stdout);
	lua_pushstring(this->L, str);
}

// Pop string from the stack :3
LPCSTR thatluashit::poplpcstr() {
	const char* instr = lua_tostring(L, -1);
	char* my_copy = (char*)malloc(strlen(instr) + 1);
	strcpy(my_copy, instr);
	lua_pop(this->L, 1);
	return my_copy;
}

// Lock and unlock

void thatluashit::getLock()
{
	// TODO: Check for abandoned mutex?
	DWORD dwWaitResult = WaitForSingleObject(this->hLuaMutex, INFINITE);
}

void thatluashit::releaseLock()
{
	ReleaseMutex(this->hLuaMutex);
}

void thatluashit::pushpathlist(const char *variablename, const char * directoryname)
{
	lua_newtable(this->L);
	int i = 1;
	for (const auto & entry : fs::directory_iterator(directoryname)){
		const char *path = entry.path().relative_path().generic_string().c_str();
		lua_pushlstring(this->L, path, strlen(path));
		lua_rawseti(this->L, -2, i);
		i++;
	}
	lua_setglobal(this->L, variablename);
}

void thatluashit::pushenv(const char *variablename)
{
	lua_newtable(this->L);
	environment_t env = get_env();
	int i = 1;

	for (auto const& x : env)
	{
		pushlpcwstr(x.first.c_str()); /* Pushes table value on top of Lua stack */
		pushlpcwstr(x.second.c_str()); /* Pushes table value on top of Lua stack */
		lua_settable(L, -3);
		i++;
	}

	lua_setglobal(this->L, variablename);
}

LPCSTR thatluashit::callfunction(const char *funcname, const char *args,...)
{
	this->getLock();
	this->setFunctionName(funcname);
	va_list vl;
	va_start(vl,args);
	int numargs = strlen(args);
	for (int i = 0; i < numargs; i++) {
		LPCSTR str = va_arg(vl,LPCSTR);
		this->pushlpcstr(str);
	}
	va_end(vl);
	this->executeFunction(numargs, 1);
	LPCSTR returner = lua->poplpcstr();
	this->releaseLock();
	return returner;
}

LPCWSTR thatluashit::callfunctionw(const char *funcname, const char *args, ...)
{
	this->getLock();
	this->setFunctionName(funcname);
	va_list vl;
	va_start(vl, args);
	int numargs = strlen(args);
	for (int i = 0; i < numargs; i++) {
		LPCWSTR str = va_arg(vl, LPCWSTR);
		this->pushlpcwstr(str);
	}
	va_end(vl);
	this->executeFunction(numargs, 1);
	LPCWSTR returner = lua->poplpcwstr();
	this->releaseLock();
	return returner;
}

static int l_getdirectory(lua_State *L)
{

	const char* directory = lua_tostring(L, 1);
	lua_newtable(L);
	int i = 1;
	for (const auto & entry : fs::recursive_directory_iterator(directory)) {
		// For some unknown reason *not* doing the string conversion in *multiple steps* deallocates the bin\hammer_run_map_launcher.exe string but not anything else
		std::string path_str = entry.path().string();
		const char* path = path_str.c_str();
		if(!fs::is_directory(path))
		{
			lua_pushstring(L, path);
			lua_rawseti(L, -2, i);
			LIAR_DEBUG("Path to load: %s\n", path);
			i++;
		}
	}
	return 1;
}