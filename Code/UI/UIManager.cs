using FancyCore.Godot.UI;
using Godot;
using System.Collections.Generic;

namespace Orcajam2023.Code.UI
{
	public enum ScreenID
	{
		None = 0,

		MainMenu = 100,
		EscMenu = 101,

		InGame = 200
	}

	public partial class UIManager : UIManagerBase<UIManager, ScreenID>
	{
		[Export] public Screen? MainMenuScreen;
		[Export] public Screen? EscMenuScreen;
		[Export] public Screen? InGameScreen;

		[Export] public override ScreenID StartScreen { get; set; }

		protected override Dictionary<ScreenID, Screen?> Screens { get; } = new();

		public override void _Ready()
		{
			Screens.Add(ScreenID.MainMenu, MainMenuScreen);
			Screens.Add(ScreenID.EscMenu, EscMenuScreen);
			Screens.Add(ScreenID.InGame, InGameScreen);

			base._Ready();
		}

		public void GotoPauseMenu()
		{
			ShowScreen(ScreenID.EscMenu);
		}

		public void GotoIngameScreen()
		{
			ShowScreen(ScreenID.InGame);
		}
	}
}
