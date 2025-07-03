using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	// this makes the Speed variable accessable to godots ui editor
	[Export]
	public float Speed { get; set; } = 200.0f;

	// _PhysicsProcess is called automatically by godot every physics frame
	// we can override the default _PhysicsProcess call on a node which allows us to program in specific physics processes
	public override void _PhysicsProcess(double delta)
	{
		// we initialize a Vector2 such that we have a default movement vector
		Vector2 direction = Vector2.Zero;

		// check for input from the arrow keys
		// ui_right, ui_left, ui_up, and ui_down are the default input keywords in godot
		// those can be changed in godot in Project -> Project Settings -> Input Map
		if (Input.IsActionPressed("ui_right"))
		{
			direction.X += 1; // move right
		}
		if (Input.IsActionPressed("ui_left"))
		{
			direction.X -= 1; // move left
		}
		if (Input.IsActionPressed("ui_up"))
		{
			direction.Y -= 1; // move up
		}
		if (Input.IsActionPressed("ui_down"))
		{
			direction.Y += 1; // move down
		}

		// normalize the vector in the case of diagonal movement
		// this prevents the phenomenon of diagonal movement resultant from a^2 + b^2 being 'faster' than expected
		// in godot movement is frame rate independent (TODO: look into this)
		if (direction.Length() > 0)
		{
			direction = direction.Normalized();
		}

		// calculate the velocity based on the direction and speed
		Velocity = direction * Speed;

		// MoveAndSlide() is the core method for CharacterBody2D movement in godot
		// it moves the character and automatically handles collision detection
		MoveAndSlide();
	}

}
