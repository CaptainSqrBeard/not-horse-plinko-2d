using Godot;
using System;

public partial class ButtonVisuals : Node
{
	[Export] TextureButton Button;
	[Export] Label ButtonLabel;
	[Export] Vector2 Offset = new (-4f, 4f);

    BaseButton.DrawMode _prevState;
	bool _rainbow = false;

	Vector2 baseTextPos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		baseTextPos = ButtonLabel.Position;
	}

	public override void _Process(double delta)
	{
		if (_rainbow)
		{
			Button.Modulate = Tools.RainbowColor();
		}
	}

	public void Draw()
	{
		Button.Modulate = new Color("ffffff");
		ButtonLabel.Position = baseTextPos;

		switch (Button.GetDrawMode())
		{
			case BaseButton.DrawMode.Normal:
				_rainbow = false;
				break;
			case BaseButton.DrawMode.Pressed:
				_rainbow = true;
				ButtonLabel.Position = baseTextPos + Offset;
				break;
			case BaseButton.DrawMode.Hover:
				_rainbow = true;
				break;
			case BaseButton.DrawMode.HoverPressed:
				_rainbow = true;
				ButtonLabel.Position = baseTextPos + Offset;
				break;
			case BaseButton.DrawMode.Disabled:
				_rainbow = false;
				break;
		}
	}
}
