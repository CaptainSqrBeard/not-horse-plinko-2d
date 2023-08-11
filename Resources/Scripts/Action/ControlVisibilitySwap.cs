using Godot;
using System;

/// <summary>
/// Swaps visibility for two 2D nodes.
/// </summary>
public partial class ControlVisibilitySwap : Node
{
	[Export] Control node_1;
	[Export] Control node_2;
	bool _state;

	public override void _Ready()
	{
		UpdateStates();
	}

	public void Swap()
	{
		_state = !_state;
		UpdateStates();
	}

	public void Node1()
	{
		_state = false;
		UpdateStates();
	}
	
	public void Node2()
	{
		_state = true;
		UpdateStates();
	}

	public void UpdateStates()
	{
		node_1.Visible = !_state;
		node_2.Visible = _state;
	}
}