using Godot;

public partial class Main : Node
{
    PackedScene BasePlayer;
    Player P1,P2;
    Node2D Map, Spawn;

    public override void _Ready()
    {
        var BasePlayer = ResourceLoader.Load<PackedScene>("res://Tscns/Player.tscn");
        Map = GetNode<Node2D>("Map");
        Spawn = Map.GetNode<Node2D>("Spawn");
    }

    public override void _Process(double delta)
	{
		
	}

    public void Init(int i)
    {
        switch (i) {
            case 1:
                if (P1.IsInsideTree())
                    P1.QueueFree();
                P1 = BasePlayer.Instantiate<Player>();
                P1.numero = 1;
                P1.Position = Spawn.Position;
                Map.AddChild(P1);
                break;
            case 2:
                P2 = BasePlayer.Instantiate<Player>();
                P2.numero = 2;
                P2.Position = Spawn.Position;
                Map.AddChild(P2);
                break;
        }
    }
}