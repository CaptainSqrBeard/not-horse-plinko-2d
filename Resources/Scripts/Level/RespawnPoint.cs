using Godot;
using System;

public partial class RespawnPoint : Node2D
{
	[Signal] public delegate void OnRespawnEventHandler();

	[Export] PackedScene RespawnPlayer;
	[Export] bool RespawnOnReady = false;

	EventBus _eventBus;

	public override void _Ready()
    {
		_eventBus = GetNode<EventBus>("/root/EventBus");

        _eventBus.Connect(EventBus.SignalName.OnPlayerDestroy, Callable.From(BeginRespawn));

		if (RespawnOnReady)
		{
			Respawn();
		}
	}

	public void BeginRespawn()
	{
		EmitSignal(SignalName.OnRespawn);
	}

	public void Respawn()
	{
		var node = (Node2D) RespawnPlayer.Instantiate();
        GetTree().CurrentScene.AddChild(node);

		node.GlobalPosition = GlobalPosition;
	}
}
