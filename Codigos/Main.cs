using Godot;

public partial class Main : Node
{
    public int Creditos = 5;
    PackedScene BasePlayer;
    Player P1,P2;
    Node2D Map, Spawn1, Spawn2;

    public override void _Ready()
    {
        var BasePlayer = ResourceLoader.Load<PackedScene>("res://Tscns/Player.tscn");
        Map = GetNode<Node2D>("Map");
        Spawn1 = Map.GetNode<Node2D>("Spawn1");
        Spawn2 = Map.GetNode<Node2D>("Spawn2");
    }

    public override void _Process(double delta)
    {
        if (Creditos > 0)
        {
            if (P1 == null & Input.IsActionJustPressed("Y"))
            {
                Spawn(1);
                Creditos--;
            }

            if (P2 == null & Input.IsActionJustPressed("3"))
            {
                Spawn(2);
                Creditos--;
            }
        }
    }

    public void Spawn(int i)
    {
        switch (i) {
            case 1:
                if (P1.IsInsideTree())
                    P1.QueueFree();
                P1 = BasePlayer.Instantiate<Player>();
                P1.Init(1);
                P1.Position = Spawn1.Position;
                Map.AddChild(P1);
                break;
            case 2:
                P2 = BasePlayer.Instantiate<Player>();
                P2.Init(2);
                P2.Position = Spawn2.Position;
                Map.AddChild(P2);
                break;
        }
    }
}