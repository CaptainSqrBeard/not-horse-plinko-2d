using Godot;
using System;

public partial class PlayerController : Node
{
	[Signal] public delegate void UpEventHandler();
	[Signal] public delegate void UpStartEventHandler();
	[Signal] public delegate void UpStopEventHandler();

	[Signal] public delegate void LeftEventHandler();
	[Signal] public delegate void RightEventHandler();

	bool _upPreviousState;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_upPreviousState = Input.IsActionPressed("Up");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var upState = Input.IsActionPressed("Up");
		if (upState) EmitSignal(SignalName.Up);
		
		if (_upPreviousState != upState)
		{
			_upPreviousState = upState;
			if (upState)
			{
				EmitSignal(SignalName.UpStart);
			}
			else
			{
				EmitSignal(SignalName.UpStop);
			}
		}

		if (Input.IsActionPressed("Left")) EmitSignal(SignalName.Left);
		if (Input.IsActionPressed("Right")) EmitSignal(SignalName.Right);
	}
}
