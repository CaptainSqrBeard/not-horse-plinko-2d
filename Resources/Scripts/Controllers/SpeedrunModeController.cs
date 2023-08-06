using Godot;
using System;

public partial class SpeedrunModeController : Node
{
	SpeedrunManager _speedrunManager;

	public override void _Ready()
	{
		_speedrunManager = GetNode<SpeedrunManager>("/root/SpeedrunManager");
	}

	public void Enable()
	{
		_speedrunManager.EnableSpeedrunMode();
	}
	
	public void Disable()
	{
		_speedrunManager.DisableSpeedrunMode();
	}
}
