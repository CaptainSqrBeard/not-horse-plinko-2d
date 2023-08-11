using Godot;
using System;

public partial class GameplayScene : Node
{
	EventBus _eventBus;

	public override void _Ready()
    {
		_eventBus = GetNode<EventBus>("/root/EventBus");
		_eventBus.EmitSignal(EventBus.SignalName.OnGameplayStart);

		Connect(SignalName.TreeExited, Callable.From(OnExit));
	}

	public void OnExit()
	{
		_eventBus.EmitSignal(EventBus.SignalName.OnGameplayEnd);
	}
}
