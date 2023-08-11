using Godot;
using System;

public partial class Goal : Node
{
	EventBus _eventBus;

	public override void _Ready()
    {
		_eventBus = GetNode<EventBus>("/root/EventBus");
	}

	public void Complete()
	{
		_eventBus.EmitSignal(EventBus.SignalName.OnGoal);
	}
}

