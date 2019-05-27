#pragma once
#include <map>

typedef std::map<std::wstring, std::wstring> environment_t;
environment_t get_env();
