using Godot;
using System;

public partial class God : Node
{
	public static God Lambda { get; set; }
	public Main Main;

	public override void _Ready()
	{
		Lambda = this;
        Main = GetTree().Root.GetNode<Main>("Main");
    }
}
