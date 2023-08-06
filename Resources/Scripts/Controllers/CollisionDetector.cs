using Godot;
using System;
using System.Collections;


public partial class CollisionDetector : Node
{
	[Export] public string ValidMetadata;
	[Signal] public delegate void OnValidCollisionEventHandler();

	public void OnBodyEntered(Node body)
	{
		if (body.HasMeta(ValidMetadata))
		{
			EmitSignal(SignalName.OnValidCollision);
		}
	}
}
