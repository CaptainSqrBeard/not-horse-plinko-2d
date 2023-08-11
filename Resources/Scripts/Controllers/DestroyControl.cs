using Godot;
using System;

public partial class DestroyControl : Node
{
	[Signal] public delegate void DeathEventHandler();

    public bool Destroyed = false;

    EventBus _eventBus;

	public override void _Ready()
	{
		_eventBus = GetNode<EventBus>("/root/EventBus");
	}

    public void Destroy()
    {
        if (Destroyed) return;

        _eventBus.EmitSignal(EventBus.SignalName.OnPlayerDestroy);
        EmitSignal(SignalName.Death);
        Destroyed = true;
    }
}
