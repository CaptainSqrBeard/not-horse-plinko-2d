using Godot;
using System;

public partial class SceneController : Node
{
	[Export] string ScenePath;
	SceneTransition _sceneTransition;

	public override void _Ready()
	{
		_sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
	}
	
	public void ChangeScene()
	{
		var packedScene = ResourceLoader.Load<PackedScene>(ScenePath);
		_sceneTransition.StartTransition(packedScene);
	}

	public void ChangeSceneByPacked(PackedScene scene)
	{
		_sceneTransition.StartTransition(scene);
	}

	public void ChangeSceneByPacked(PackedScene scene, string animationIn, string animationOut)
	{
		_sceneTransition.StartTransition(scene, animationIn, animationOut);
	}

	public void ChangeSceneByString(string scene)
	{
		var packedScene = ResourceLoader.Load<PackedScene>(scene);
		ChangeSceneByPacked(packedScene);
	}

	public void ChangeSceneByString(string scene, string animationIn, string animationOut)
	{
		var packedScene = ResourceLoader.Load<PackedScene>(scene);
		ChangeSceneByPacked(packedScene, animationIn, animationOut);
	}
}
