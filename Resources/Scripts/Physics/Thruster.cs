using Godot;
using System;

public partial class Thruster : Node2D
{
	[Export] RigidBody2D Body;
	[Export] float Force = 1000f;

	public bool State = false;

	public override void _PhysicsProcess(double delta)
	{
		if (State)
		{
			Body.ApplyForce(new Vector2(0, -Force).Rotated(GlobalRotation));
		}
	}

	public void SetState(bool state)
	{
		State = state;
	}
}
