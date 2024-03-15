using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	[Export(PropertyHint.Range, "0,10000,5")]
	public float Acceleration;

	[Export(PropertyHint.Range, "0,5000,5")]
	public float Deceleration;

	[Export(PropertyHint.Range, "100,800,10")]
	public float MaxSpeed;

	public Vector2 Direction;

	[Signal]
	public delegate void ToggleInventoryEventHandler();


	public override void _PhysicsProcess(double delta)
	{
		DoMovement(delta);

		if (Input.IsActionJustPressed("inventory"))
		{
			EmitSignal(SignalName.ToggleInventory);
		}
	}

	private void DoMovement(double delta)
	{
		var fDelta = (float)delta;

		Direction = Vector2.Zero;

		if (Input.IsActionPressed("move_left"))
		{
			Direction.X -= 1.0f;
		}

		if (Input.IsActionPressed("move_right"))
		{
			Direction.X += 1.0f;
		}

		if (Input.IsActionPressed("move_up"))
		{
			Direction.Y -= 1.0f;
		}

		if (Input.IsActionPressed("move_down"))
		{
			Direction.Y += 1.0f;
		}

		if (Direction != Vector2.Zero)
		{
			Direction = Direction.Normalized();

			var accelerationVector = Direction * Acceleration * fDelta;

			var speed = Velocity + accelerationVector;

			Velocity = speed.LimitLength(MaxSpeed);
		}
		else
		{
			if (Velocity.Length() > Deceleration * fDelta)
			{
				Velocity -= Velocity.Normalized() * Deceleration * fDelta;
			}
			else
			{
				Velocity = Vector2.Zero;
			}
		}

		MoveAndSlide();
	}

}
