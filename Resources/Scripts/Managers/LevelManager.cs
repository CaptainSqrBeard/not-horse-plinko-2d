using Godot;
using System;
using System.Collections.Generic;

public partial class LevelManager : Node
{
	[Signal] public delegate void OnLevelCompleteEventHandler();
	[Signal] public delegate void OnLevelRestartEventHandler();

    [Export] string NextLevelPath;
    
    public LevelState CurrentLevelState = LevelState.IN_PROGRESS;

	SceneTransition _sceneTransition;
	SpeedrunManager _speedrunManager;
    EventBus _eventBus;
	SettingsManager _settings;

    PackedScene FirstLevel;

    const string FIRST_LEVEL_PATH = "res://Resources/Scenes/Level1.scn";

    //const string RocketResourcePath = "res://Resources/Objects/Rocket.tscn";
    //Node2D Rocket;
    //Node2D Spawnpoint;

	public override void _Ready()
	{
		_sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
		_speedrunManager = GetNode<SpeedrunManager>("/root/SpeedrunManager");
		_eventBus = GetNode<EventBus>("/root/EventBus");
		_settings = GetNode<SettingsManager>("/root/SettingsManager");

        _speedrunManager.StartTimer();

        FirstLevel = ResourceLoader.Load<PackedScene>(FIRST_LEVEL_PATH);

        _eventBus.Connect(EventBus.SignalName.OnPlayerDestroy, Callable.From(BeginRestartLevel));
        _eventBus.Connect(EventBus.SignalName.OnGoal, Callable.From(BeginCompleteLevel));
	}

    public void BeginCompleteLevel()
    {
        // you can't complete level after you fail it
        if (CurrentLevelState != LevelState.IN_PROGRESS) return;

        CurrentLevelState = LevelState.COMPLETED;
        EmitSignal(SignalName.OnLevelComplete);
    }
    
    public void BeginRestartLevel()
    {
        // but you can fail level if you completed it but were not alive until it ends
        if (CurrentLevelState == LevelState.FAILED) return;

        CurrentLevelState = LevelState.FAILED;
        EmitSignal(SignalName.OnLevelRestart);
    }

    public void CompleteLevel()
    {
        if (CurrentLevelState == LevelState.FAILED) return;

        CurrentLevelState = LevelState.COMPLETED;
        
        _sceneTransition.StartTransitionByPath(NextLevelPath);
    }

    public void RestartLevel()
    {
        CurrentLevelState = LevelState.FAILED;

        if (_settings.FirstAttempt)
        {
            _speedrunManager.Finish();
            _sceneTransition.StartTransition(FirstLevel, "TransitionInFast", "TransitionOutFast");
        }
        else
        {
            _sceneTransition.StartTransition(_sceneTransition.CurrentScene, "TransitionInFast", "TransitionOutFast");
        }
    }

    public enum LevelState
    {
        IN_PROGRESS,
        COMPLETED,
        FAILED
    }
}
