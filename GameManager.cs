using FancyCore.Godot;
using Godot;
using Orcajam2023.Code.UI;
using System.Collections.Generic;
using System.Diagnostics;

public partial class GameManager : Singleton<GameManager>
{
	[Export] public PackedScene? BonesPrefab;
	[Export] public PackedScene? SeedPrefab;
	[Export] public TileMap? Map;

	[Export] public Timer? FireTimer;

	[Export] public int MaxMana = 100;
	[Export] public int SummonManaCost = 100;
	[Export] public float TreeGrowTime = 10;

	[Export] public int StartBones = 10;
	[Export] public int StartSeeds = 5;
	[Export] public int ManaPerSeed = 5;

	private Vector2I TileCellSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void StartGame()
	{
		Debug.Assert(Map != null);
		Debug.Assert(BonesPrefab != null);
		Debug.Assert(SeedPrefab != null);

		List<Vector2I> pathable_tiles = new();
		TileCellSize = Map.TileSet.TileSize;

		foreach (Vector2I cell_pos in Map.GetUsedCells(0))
		{
			Vector2I atlas_pos = Map.GetCellAtlasCoords(0, cell_pos);
			if (atlas_pos.X != 0)
			{
				pathable_tiles.Add(cell_pos);
			}
		}

		for (int i = 0; i < StartBones; i++)
		{
			Vector2I spawnPos = pathable_tiles.RandomElement();

			//spawn bones
			Node2D boneInst = BonesPrefab.Instantiate<Node2D>();
			boneInst.Position = TileMapPos(spawnPos);
			AddChild(boneInst);

			pathable_tiles.Remove(spawnPos);
		}

		for (int i = 0; i < StartSeeds; i++)
		{
			Vector2I spawnPos = pathable_tiles.RandomElement();

			//spawn seed
			Node2D seedInst = SeedPrefab.Instantiate<Node2D>();
			seedInst.Position = TileMapPos(spawnPos);
			AddChild(seedInst);

			pathable_tiles.Remove(spawnPos);
		}

		UIManager.Instance?.ShowScreen(ScreenID.InGame);
	}

	public override void _Process(double delta)
	{
		if (UIManager.Instance?.ActiveScreen == ScreenID.InGame)
		{

		}
	}

	public void TrySkeletonSummon()
	{

	}

	public void TryPlantTree()
	{

	}

	public void TryHarvestTree()
	{

	}

	public void CancelCurrentAction()
	{

	}

	public void Quit()
	{
		GetTree().Quit();
	}

	public Vector2I TileMapPos(Vector2I tileIndex)
	{
		return tileIndex * TileCellSize + TileCellSize / 2;
	}
}
