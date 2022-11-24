#pragma once
#ifdef NEXPLAYER_EXPORTS
#   define NEXPLAYER_API __declspec(dllexport)
#else
#   define NEXPLAYER_API __declspec(dllimport)
#endif

// function called on pause events
extern "C" NEXPLAYER_API void OnPlayPause(int current_playback_time);
// function called at the start
extern "C" NEXPLAYER_API void ResetPlayPauseEvents();
extern "C" NEXPLAYER_API int GetNumberOfPlayPauseEvents();
extern "C" NEXPLAYER_API int GetLastPlayPauseTimestamp();