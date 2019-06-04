#pragma once
#define LIAR_LEVEL_DEBUG
#ifdef LIAR_LEVEL_DEBUG
	#define LIAR_DEBUG(...) printf(__VA_ARGS__); fflush(stdout);
#else
	#define LIAR_DEBUG(...);
#endif
#ifdef LIAR_LEVEL_INTRICATE
	#define LIAR_DEBUG_INTRICATE(...) printf(__VA_ARGS__); fflush(stdout);
#else
#define LIAR_DEBUG_INTRICATE(...);
#endif