using FancyCore.Godot.UI;
using Godot;
using Godot.Collections;
using System.Threading.Tasks;

public partial class InGameUI : SimpleScreen
{
	public enum ControlID
	{
		Main,
		SummonSkeletons,
		PlantTree,
		HarvestTree
	}

	[Export] public Control? MainControls;
	[Export] public Control? SummonSkeletonControls;
	[Export] public Control? PlantTreeControls;
	[Export] public Control? HarvestTreeControls;

	private Dictionary<ControlID, Control?> Controls = new();

	private Control? CurrentControls;

	public override void _Ready()
	{
		Controls.Add(ControlID.Main, MainControls);
		Controls.Add(ControlID.SummonSkeletons, SummonSkeletonControls);
		Controls.Add(ControlID.PlantTree, PlantTreeControls);
		Controls.Add(ControlID.HarvestTree, HarvestTreeControls);

		base._Ready();
	}

	public override Task ShowScreen()
	{
		foreach (Control? control in Controls.Values)
		{
			if (control != null)
			{
				control.Visible = false;
			}
		}
		SetControls(ControlID.Main);

		return base.ShowScreen();
	}

	public override Task HideScreen()
	{
		GameManager.Instance?.CancelCurrentAction();

		return base.HideScreen();
	}

	public void SetControls(ControlID controls)
	{

		if (Controls.TryGetValue(controls, out Control? control) && control != null)
		{
			if (CurrentControls != null)
			{
				CurrentControls.Visible = false;
			}

			control.Visible = true;
			CurrentControls = control;
		}
	}

	public void SkeletonSummon()
	{
		SetControls(ControlID.SummonSkeletons);
		GameManager.Instance?.TrySkeletonSummon();
	}

	public void PlantTree()
	{
		SetControls(ControlID.PlantTree);
		GameManager.Instance?.TryPlantTree();
	}

	public void HarvestTree()
	{
		SetControls(ControlID.HarvestTree);
		GameManager.Instance?.TryHarvestTree();
	}

	public void CancelCurrentTask()
	{
		SetControls(ControlID.Main);
		GameManager.Instance?.CancelCurrentAction();
	}
}
