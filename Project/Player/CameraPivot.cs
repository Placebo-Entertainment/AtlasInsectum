using Godot;
using System;

public partial class CameraPivot : Node2D
{
	private PlayerController parent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		parent = GetParent<PlayerController>();
	}

	public override void _PhysicsProcess(double delta)
	{
		Rotation = parent.Direction.Angle();
	}

}
