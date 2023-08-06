using Godot;
using System;

public partial class SpeedrunEnd : Node
{
    [Export] Label SpeedrunTime;

	SpeedrunManager _speedrunManager;
	public override void _Ready()
	{
		_speedrunManager = GetNode<SpeedrunManager>("/root/SpeedrunManager");

        _speedrunManager.StopTimer();
        if (SpeedrunTime != null)
        {
            SpeedrunTime.Text = _speedrunManager.EndTime.ToString("hh\\:mm\\:ss\\.fff");
        }  
	}
}
