using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using NexPlayerAPI;
using TMPro;

public class NexPlayerDLLHandler : NexPlayerBehaviour
{
    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI eventNum;
    [SerializeField] TextMeshProUGUI lastTimestamp;

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

    private void OnGUI()
    {
        eventNum.text = "Event num: " + GetNumberOfPlayPauseEvents().ToString();
        lastTimestamp.text = "Last time: " + GetLastPlayPauseTimestamp().ToString();
    }
}
