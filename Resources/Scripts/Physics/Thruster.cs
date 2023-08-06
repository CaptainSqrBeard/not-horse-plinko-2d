using Godot;
using System;

public partial class Thruster : Node2D
{
	[Export] RigidBody2D Body;
	[Export] float Force = 1000f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void Forward()
    {
        Forward(Force);
    }

    public void Forward(float force)
    {
        Body.ApplyForce(new Vector2(0, -force).Rotated(GlobalRotation));
    }
}
