using Godot;
using System;

public partial class Goal : Node
{
	LevelManager _levelManager;

	public override void _Ready()
	{
		_levelManager = GetTree().CurrentScene.GetNode<LevelManager>("LevelManager");
		if (_levelManager == null)
		{
			GD.PushWarning("Goal has no LevelManager!");
			QueueFree();
		}
	}

	public void Complete()
	{
		_levelManager.CompleteLevel();
	}
}
