using Godot;
using System;

public partial class Rotator : Node2D
{
	[Export] Node2D Node;
	[Export] float Torque = 10f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        
	}

    public void Left()
    {
        Left(Torque);
    }

    public void Right()
    {
        Right(Torque);
    }

    public void Left(float torque)
    {
        Node.Rotate(-torque * (float) GetProcessDeltaTime());
    }

    public void Right(float torque)
    {
        Node.Rotate(torque * (float) GetProcessDeltaTime());
    }
}
