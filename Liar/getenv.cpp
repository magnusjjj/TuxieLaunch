#include <map>
#include <Windows.h>
#include <memory>
#include "getenv.h"

// From: https://stackoverflow.com/questions/9535112/get-all-env-variables-in-c-c-on-windows

environment_t get_env() {
	environment_t env;

	auto free = [](wchar_t* p) { FreeEnvironmentStringsW(p); };
	auto env_block = std::unique_ptr<wchar_t, decltype(free)>{
		GetEnvironmentStringsW(), free };

	for (const wchar_t* name = env_block.get(); *name != L'\0'; )
	{
		const wchar_t* equal = wcschr(name, L'=');
		std::wstring key(name, equal - name);

		const wchar_t* pValue = equal + 1;
		std::wstring value(pValue);

		env[key] = value;

		name = pValue + value.length() + 1;
	}

	return env;
}