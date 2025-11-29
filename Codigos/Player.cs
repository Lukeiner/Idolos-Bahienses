using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public int numero = 0;
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
<<<<<<< Updated upstream

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
=======
	public AnimationPlayer anim;
	double FStop=0;
	int t = 0;
	string[] keys= new string[] { "W","A","S","D","T","Y","U","Up", "Le", "Do", "Ri", "1", "2", "3" };
    public override void _Ready()
    {
		anim = GetNode<AnimationPlayer>("Anim");
    }
	public void Init(int i)
	{
		
		anim.Play("Start");
		FStop = 0.3333;
		if (i == 2)
		{
			t = 7;
			CollisionLayer = 2;
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector(keys[1+t], keys[3+t], keys[0+t], keys[2+t]);
		if (direction != Vector2.Zero && FStop == 0)
>>>>>>> Stashed changes
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
