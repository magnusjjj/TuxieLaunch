#pragma once


#define LIAR_DEBUG(...) printf(__VA_ARGS__); fflush(stdout);

#ifdef LIAR_LEVEL_INTRICATE
	#define LIAR_DEBUG_INTRICATE(...) printf(__VA_ARGS__); fflush(stdout);
#else
#define LIAR_DEBUG_INTRICATE(...);
#endif