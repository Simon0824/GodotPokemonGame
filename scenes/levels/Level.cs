using Game.Core;
using Godot;
using System;
namespace Game.Gameplay
{
    public partial class Level : Node2D
    {
        [ExportCategory("Level Basics")]
        [Export]
        public LevelName LevelName;

        [ExportCategory("Camera Limits")]
        [Export]
        public int Top;

        [Export]
        public int Right;

        [Export]
        public int Bottom;

        [Export]
        public int Left;

        public override void _Ready()
        {
            Logger.Info($"Loading level{LevelName} ..."); 
        }

    }

}
