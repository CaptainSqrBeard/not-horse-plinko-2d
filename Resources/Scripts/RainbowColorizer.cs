using Godot;
using System;

public partial class RainbowColorizer : Node
{
	[Export] Node2D ColorizedNode;
	[Export] float Speed = 1f;
	[Export] float Saturation = 1f;
	[Export] float Value = 1f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ColorizedNode == null)
		{
			GD.PushWarning("RainbowColorizer has no node to colorize!");
			QueueFree();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ColorizedNode.Modulate = Tools.RainbowColor(Speed, Saturation, Value);
	}
}
