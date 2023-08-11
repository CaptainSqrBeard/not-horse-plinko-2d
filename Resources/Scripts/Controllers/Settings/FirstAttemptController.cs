using Godot;
using System;

public partial class FirstAttemptController : Node
{
    [Export] BaseButton Button;
	SettingsManager _settings;

	public override void _Ready()
    {
		_settings = GetNode<SettingsManager>("/root/SettingsManager");
		Button?.SetPressedNoSignal(_settings.FirstAttempt);
	}

	public void SetValue(bool value)
	{
		_settings.FirstAttempt = value;
		GD.Print($"now {value}");
	}
}
