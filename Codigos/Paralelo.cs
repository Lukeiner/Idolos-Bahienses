using Godot;
using System;

public partial class Paralelo : Node2D
{
	[Export]
	int i = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Position.X < -960)
		{
			Position += Vector2.Right * 1920;
        }
        if (Position.X > 2880)
        {
            Position += Vector2.Left * 1920;
        }
    }
}
