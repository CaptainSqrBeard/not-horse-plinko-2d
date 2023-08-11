using Godot;
using System;

public partial class ToggleButtonSignals : Node
{
	[Signal] public delegate void OnEnableEventHandler();
	[Signal] public delegate void OnDisableEventHandler();

	public void Toggle(bool state)
	{
		if (state)
		{
			EmitSignal(SignalName.OnEnable);
		}
		else
		{
			EmitSignal(SignalName.OnDisable);
		}
	}
}
