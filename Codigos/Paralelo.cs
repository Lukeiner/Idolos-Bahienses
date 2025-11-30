using Godot;
using System;

public partial class Paralelo : Node2D
{
	[Export]
	int i = 0;//0=calle, 1 = proximo, 2 = medio, 3 = lejos
    float x=0;
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    bool bo = true;
    Vector2 reset;
    public override void _Ready()
    {
        reset = Position;
    }
	public override void _Process(double delta)
	{
        
        if (GlobalPosition.X < -1920)
        {
            GlobalPosition += Vector2.Right * 3840*2;
        }
        if (bo)
        {
            bo = false;
            Position = reset;
            x = God.Lambda.Main.Cam.GlobalPosition.X;
        }
        var _x=God.Lambda.Main.Camera.GlobalPosition.X;
        if (!God.Lambda.Main.boMap)
        {

            switch (i)
            {
                case 1:
                    GlobalPosition += Vector2.Right * 0.2f * (x - _x);
                    break;
                case 2:
                    GlobalPosition += Vector2.Right * 0.3f * (x - _x);
                    break;
                case 3:
                    GlobalPosition += Vector2.Right * 0.4f * (x - _x);
                    break;
            }
        }
        x = _x;
    }
}
