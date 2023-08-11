using Godot;
using System;

public partial class SpeedrunModeController : Node
{
	[Export] BaseButton Button;
	SpeedrunManager _speedrunManager;

	public override void _Ready()
	{
		_speedrunManager = GetNode<SpeedrunManager>("/root/SpeedrunManager");
		Button?.SetPressedNoSignal(_speedrunManager.SpeedrunMode);
	}

	public void Enable()
	{
		_speedrunManager.EnableSpeedrunMode();
		GD.Print($"enable");
	}
	
	public void Disable()
	{
		_speedrunManager.DisableSpeedrunMode();
		GD.Print($"disable");
	}
}
