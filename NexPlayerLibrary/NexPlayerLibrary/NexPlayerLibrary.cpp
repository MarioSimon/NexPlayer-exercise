#include "pch.h"
#include "NexPlayerLibrary.h"
#include <list>

using namespace std;

// list of timestamps
list<int> timestamps;


void OnPlayPause(int current_playback_time)
{
	timestamps.push_back(current_playback_time);
}

int GetNumberOfPlayPauseEvents() 
{
	return timestamps.size();
}

int GetLastPlayPauseTimestamp()
{
	if (timestamps.size() > 0) 
	{
		return timestamps.back();
	}
	return -1;
}
