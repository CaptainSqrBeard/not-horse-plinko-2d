using Godot;
using System;

public partial class GameStopper : Node
{
	public void Stop()
	{
		GetTree().Quit();
	}
}
