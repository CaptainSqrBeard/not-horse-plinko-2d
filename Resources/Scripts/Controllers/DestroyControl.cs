using Godot;
using System;
using System.Collections.Generic;

public partial class DestroyControl : Node
{
	[Signal] public delegate void DeathEventHandler();
    [Export] public Node Destroyable;

    public bool Destroyed = false;

    public void Destroy()
    {
        if (Destroyed) return;

        EmitSignal(SignalName.Death);
        Destroyed = true;
        
        Destroyable.QueueFree();
    }
}
