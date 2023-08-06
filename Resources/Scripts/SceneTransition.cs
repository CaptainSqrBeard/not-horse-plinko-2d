using Godot;
using System;

public partial class SceneTransition : Node
{
	[Export] AnimationPlayer Animation;

	const string DefaultAnimationIn = "TransitionIn";
	const string DefaultAnimationOut = "TransitionOut";

	public TransitionState State;
	public PackedScene CurrentScene;
	
	string _animationOut;
	PackedScene _scene;
	string _scenePath;

	public enum TransitionState
	{
		None,
		In,
		Out,
	}

    public override void _Ready()
    {
        var scene_path = ProjectSettings.GetSetting("application/run/main_scene").AsString();
		CurrentScene = ResourceLoader.Load<PackedScene>(scene_path);
    }

    public void InstantTransition(PackedScene scene)
	{
		if (State == TransitionState.In) return;
		GetTree().ChangeSceneToPacked(scene);

		CurrentScene = scene;
	}

	public void StartTransition(PackedScene scene, string animationIn = DefaultAnimationIn, string animationOut = DefaultAnimationOut)
	{
		// We don't want it to change scene when it's already changing.
		// Also we don't want cancel scene transition just because it's in "Out" state
		if (State == TransitionState.In) return;

		State = TransitionState.In;
		_animationOut = animationOut;
		_scene = scene;
		_scenePath = null;

		Animation.Play(animationIn);
	}

	public void StartTransitionByPath(string scene, string animationIn = DefaultAnimationIn, string animationOut = DefaultAnimationOut)
	{
		var packedScene = ResourceLoader.Load<PackedScene>(scene);
		StartTransition(packedScene, animationIn, animationOut);
	}

	public void AnimationFinished(string _)
	{
		switch (State)
		{
			case TransitionState.In:
				GetTree().ChangeSceneToPacked(_scene);
				CurrentScene = _scene;
				Animation.Play(_animationOut);
				State = TransitionState.Out;
				break;

			case TransitionState.Out:
				State = TransitionState.None;
				break;
		}
	}

}
