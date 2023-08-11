using Godot;
using System;

public partial class LevelUIController : Node
{
	[Export] CanvasLayer UINode;
	EventBus _eventBus;

	public override void _Ready()
	{
		_eventBus = GetNode<EventBus>("/root/EventBus");

		_eventBus.Connect(EventBus.SignalName.OnGameplayStart, Callable.From(OnGameplayStart));
        _eventBus.Connect(EventBus.SignalName.OnGameplayEnd, Callable.From(OnGameplayEnd));
		
		UINode.Visible = false;
	}

	public void OnGameplayStart()
	{
		UINode.Visible = true;
	}

	public void OnGameplayEnd()
	{
		UINode.Visible = false;
	}
}
