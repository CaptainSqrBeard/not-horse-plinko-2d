using Godot;
using System;
using System.Collections.Generic;

public partial class SpeedrunManager : Node
{
    [Export] Label TimerLabel;

    public bool SpeedrunMode = false;
    public bool TimerRunning = false;

    public ulong StartTime = 0;
    public TimeSpan EndTime = new (999, 59, 59);

	public override void _Ready()
	{
		StartTime = Time.GetTicksUsec();
        //EnableSpeedrunMode();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (!SpeedrunMode || !TimerRunning) return;

        var timePassed = Time.GetTicksUsec() - StartTime;

        var timeSpan = new TimeSpan((long) timePassed * 10);

        TimerLabel.Text = timeSpan.ToString("hh\\:mm\\:ss\\.fff");
	}

    public void StartTimer()
    {
        if (TimerRunning) return;

        StartTime = Time.GetTicksUsec();
        TimerRunning = true;

        if (SpeedrunMode)
        {
            TimerLabel.Visible = true;
        }
    }

    public void StopTimer()
    {
        if (!TimerRunning) return;

        var timePassed = Time.GetTicksUsec() - StartTime;
        EndTime = new TimeSpan((long) timePassed * 10);
        TimerRunning = false;

        if (SpeedrunMode)
        {
            TimerLabel.Text = EndTime.ToString("hh\\:mm\\:ss\\.fff");
        }
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
        SpeedrunMode = true;
        if (TimerRunning)
        {
            TimerLabel.Visible = false;
        }
    }
}
