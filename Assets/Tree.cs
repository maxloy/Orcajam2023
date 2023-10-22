using Godot;

public partial class Tree : Node2D
{
	[Export] public float MinSize = 0.1f;
	[Export] public float MaxSize = 1;
	[Export] public Timer? GrowTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GrowTimer != null)
		{
			double progress = GrowTimer.TimeLeft / GrowTimer.WaitTime;

		}
	}
}
