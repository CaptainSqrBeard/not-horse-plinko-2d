using Godot;
using System;

public partial class TimerRefresh : Node
{
	[Export] Label SpeedrunTime;
	[Export] bool RefreshOnReady = true;

	SpeedrunManager _speedrunManager;
	public override void _Ready()
	{
		_speedrunManager = GetNode<SpeedrunManager>("/root/SpeedrunManager");

		if (RefreshOnReady)
		{
			_speedrunManager.Finish();
			if (SpeedrunTime != null)
			{
				var timePassed = _speedrunManager.EndTime - _speedrunManager.StartTime;
				var timeSpan = new TimeSpan((long) timePassed * 10);
				SpeedrunTime.Text = timeSpan.ToString("hh\\:mm\\:ss\\.fff");
			}
		}
	}
}
