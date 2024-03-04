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

		if (direction != Vector2.Zero)
		{
			direction = direction.Normalized();

			var accelerationVector = direction * Acceleration * fDelta;

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
