#pragma once
#include <Windows.h>
extern "C" {
	#include <lauxlib.h>
	#include <lua.h>
	#include <lualib.h>
}

class thatluashit
{
private:
	HANDLE hLuaMutex;
	lua_State *L;
public:
	thatluashit();
	~thatluashit();
	void runfile(const char * filename);
	void setFunctionName(const char * function_name);
	void executeFunction(int argumentnumber, int returnnumber);
	void pushlpcwstr(LPCWSTR str);
	void pushlpcstr(LPCSTR str);
	LPCWSTR poplpcwstr();
	LPCSTR poplpcstr();
	LPCSTR wstr_to_str(LPCWSTR str);
	void getLock();
	void releaseLock();
	void pushpathlist(const char *variablename, const char* directoryname);
	void pushenv(const char *variablename);
};

