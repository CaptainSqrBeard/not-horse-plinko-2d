using Godot;
using System;

public partial class EventBus : Node
{
    // Used when player character got destroyed
    [Signal] public delegate void OnPlayerDestroyEventHandler();

    // Used when collectible picked up
    [Signal] public delegate void OnCollectiblePickupEventHandler();

    // Used when level goal is reached
    [Signal] public delegate void OnGoalEventHandler();

    // Used when gameplay started
    [Signal] public delegate void OnGameplayStartEventHandler();
    
    // Used when gameplay ended
    [Signal] public delegate void OnGameplayEndEventHandler();
    
    // Used when you need reset speedrun
    [Signal] public delegate void SpeedrunResetEventHandler();
    
    // Used to refresh timer
    [Signal] public delegate void TimerRefreshEventHandler();
    
    // Used on pause
    //[Signal] public delegate void OnPauseHandler();

    // Used on unpause
    //[Signal] public delegate void OnUnpauseHandler();
}
