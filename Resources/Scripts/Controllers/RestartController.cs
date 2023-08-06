using Godot;
using System;
using System.Collections.Generic;

public partial class RestartController : Node
{
	[Export] string AnimationTransitionIn = "TransitionInFast";
	[Export] string AnimationTransitionOut = "TransitionOutFast";

	SceneTransition _sceneTransition;

	public override void _Ready()
	{
		_sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
	}

    public void Restart()
    {
        //_sceneTransition.InstantTransition(_sceneTransition.CurrentScene);
		_sceneTransition.StartTransition(_sceneTransition.CurrentScene, AnimationTransitionIn, AnimationTransitionOut);
    }
}
