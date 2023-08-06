using Godot;
using System;
using System.Collections.Generic;

public partial class LevelManager : Node
{
	//[Signal] public delegate void OnLevelCompleteEventHandler();
    [Export] string NextLevelPath;
    
    bool _levelCompleted = false;

	SceneTransition _sceneTransition;
	SpeedrunManager _speedrunManager;

    //const string RocketResourcePath = "res://Resources/Objects/Rocket.tscn";
    //Node2D Rocket;
    //Node2D Spawnpoint;

	public override void _Ready()
	{
		_sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
		_speedrunManager = GetNode<SpeedrunManager>("/root/SpeedrunManager");

        _speedrunManager.StartTimer();    
	}

    public void CompleteLevel()
    {
        if (_levelCompleted) return;

        _levelCompleted = true;
        //EmitSignal(SignalName.OnLevelComplete);
        
        _sceneTransition.StartTransitionByPath(NextLevelPath);
    }
}
