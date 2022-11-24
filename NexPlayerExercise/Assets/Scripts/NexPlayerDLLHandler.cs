using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using NexPlayerAPI;

public class NexPlayerDLLHandler : NexPlayerBehaviour
{

    [DllImport("NexPlayerLibrary.dll")]
    private static extern void OnPlayPause(int current_playback_time);

    [DllImport("NexPlayerLibrary.dll")]
    private static extern int GetNumberOfPlayPauseEvents();

    [DllImport("NexPlayerLibrary.dll")]
    private static extern int GetLastPlayPauseTimestamp();


    protected override void EventPlaybackStarted()
    {
        base.EventPlaybackStarted();
        OnPlayPause(GetCurrentTime());
    }

    protected override void EventPlaybackPaused()
    {
        base.EventPlaybackPaused();
        OnPlayPause(GetCurrentTime());
    }
}
