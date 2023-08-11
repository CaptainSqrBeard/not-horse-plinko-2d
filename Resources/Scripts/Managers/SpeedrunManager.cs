using Godot;
using System;
using System.Collections.Generic;

public partial class SpeedrunManager : Node
{
    [Export] Label TimerLabel;

    public bool SpeedrunMode = false;
    public bool TimerRunning = false;

    public ulong StartTime = 0;
    public ulong EndTime = 0;
    public bool Fresh = true; // If it's true, then timer must reset the next time it start
    
	EventBus _eventBus;

	public override void _Ready()
	{
		_eventBus = GetNode<EventBus>("/root/EventBus");

		StartTime = Time.GetTicksUsec();
        TimerLabel.Visible = SpeedrunMode;

        _eventBus.Connect(EventBus.SignalName.OnGameplayStart, Callable.From(StartTimer));
        _eventBus.Connect(EventBus.SignalName.OnGameplayEnd, Callable.From(StopTimer));
        _eventBus.Connect(EventBus.SignalName.TimerRefresh, Callable.From(Finish));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        // Speedrun Timer - don't process if it's disabled or timer isn't running
        if (!SpeedrunMode || !TimerRunning) return;

        var timePassed = Time.GetTicksUsec() - StartTime;

        var timeSpan = new TimeSpan((long) timePassed * 10);

        TimerLabel.Text = timeSpan.ToString("hh\\:mm\\:ss\\.fff");
	}

    public void StartTimer()
    {
        // Don't start timer while it's already running
        if (TimerRunning) return;

        // Reset timer if it's fresh
        if (Fresh)
        {
            StartTime = Time.GetTicksUsec();
            Fresh = false;
        }
        else
        {
            var timePassedAfterPause = Time.GetTicksUsec() - EndTime;
            StartTime -= timePassedAfterPause;
        }
        
        // Enable timer
        TimerRunning = true;

        // Speedrun timer visibility
        if (SpeedrunMode)
        {
            TimerLabel.Visible = true;
        }
    }

    public void StopTimer()
    {
        // Don't stop timer if it not running
        if (!TimerRunning) return;

        // Get passed time
        var timePassed = Time.GetTicksUsec() - StartTime;

        // Save timer end time if it would re-enable after some time
        EndTime = Time.GetTicksUsec();

        // Disable timer
        TimerRunning = false;

        // Speedrun timer visibility
        if (SpeedrunMode)
        {
            var timeSpan = new TimeSpan((long) timePassed * 10);
            TimerLabel.Text = timeSpan.ToString("hh\\:mm\\:ss\\.fff");
        }
    }

    public void Finish()
    {
        StopTimer();
        Fresh = true;
        TimerLabel.Visible = false;
    }

    public void EnableSpeedrunMode()
    {
        SpeedrunMode = true;
        if (TimerRunning)
        {
            TimerLabel.Visible = true;
        }
    }

    public void DisableSpeedrunMode()
    {
        SpeedrunMode = false;
        if (TimerRunning)
        {
            TimerLabel.Visible = false;
        }
    }
}
