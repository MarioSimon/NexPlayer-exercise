using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using NexPlayerAPI;
using TMPro;
using NexPlayerSample;

public class NexPlayerDLLHandler : NexPlayerBehaviour
{
    [SerializeField] NexPlayer nexPlayer;

    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI eventNum;
    [SerializeField] TextMeshProUGUI lastTimestamp;

    [DllImport("NexPlayerLibrary.dll")]
    private static extern void OnPlayPause(int current_playback_time);

    [DllImport("NexPlayerLibrary.dll")]
    private static extern void ResetPlayPauseEvents();

    [DllImport("NexPlayerLibrary.dll")]
    private static extern int GetNumberOfPlayPauseEvents();

    [DllImport("NexPlayerLibrary.dll")]
    private static extern int GetLastPlayPauseTimestamp();

    private void Start()
    {
        ResetPlayPauseEvents();
    }

    protected override void EventPlaybackStarted()
    {
        base.EventPlaybackStarted();
        OnPlayPause(nexPlayer.GetCurrentTime()/1000);
    }

    protected override void EventPlaybackPaused()
    {
        base.EventPlaybackPaused();
        OnPlayPause(nexPlayer.GetCurrentTime()/1000);
    }

    private void OnGUI()
    {
        eventNum.text = "Event num: " + GetNumberOfPlayPauseEvents().ToString();
        
        int timestamp = GetLastPlayPauseTimestamp();
        if (timestamp == -1)
        {
            lastTimestamp.text = "No timestamps yet";
            return;
        }       
        lastTimestamp.text = "Last time: " + timestamp.ToString();
    }
}
