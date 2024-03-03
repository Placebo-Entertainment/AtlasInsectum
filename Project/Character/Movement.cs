using Godot;
using System;

public partial class Movement : CharacterBody2D
{
	[Export]
	public int speed;

	private Vector2 _targetVelocity = Vector2.Zero;

	Node2D pivot;
	
	[Signal]
	public delegate void ToggleInventoryEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pivot = GetNode<Node2D>("Pivot");
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = Vector2.Zero;

		if (Input.IsActionPressed("move_left"))
		{
			direction.X -= 1.0f;
		}

		if (Input.IsActionPressed("move_right"))
		{
			direction.X += 1.0f;
		}

		if (Input.IsActionPressed("move_up"))
		{
			direction.Y -= 1.0f;
		}

		if (Input.IsActionPressed("move_down"))
		{
			direction.Y += 1.0f;
		}

		if (Input.IsActionJustPressed("inventory"))
		{
			EmitSignal(SignalName.ToggleInventory);
		}

		if (direction != Vector2.Zero)
		{
			direction = direction.Normalized();
		}

		_targetVelocity.X = direction.X * speed;
		_targetVelocity.Y = direction.Y * speed;

		Velocity = _targetVelocity;

		MoveAndSlide();
	}
}
