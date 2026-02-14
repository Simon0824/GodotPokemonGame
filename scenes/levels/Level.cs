using Game.Core;
using Godot;
using System;
using System.Collections.Generic;
namespace Game.Gameplay
{
    public partial class Level : Node2D
    {
        [ExportCategory("Level Basics")]
        [Export]
        public LevelName LevelName;

        [Export(PropertyHint.Range, "0, 100")]
        public int EncounterRate = 20;

        [ExportCategory("Camera Limits")]
        [Export]
        public int Top;

        [Export]
        public int Right;

        [Export]
        public int Bottom;

        [Export]
        public int Left;

        private readonly HashSet<Vector2> reservedTiels = [];
        public override void _Ready()
        {
            Logger.Info($"Loading level{LevelName} ..."); 
        }

        public bool ReserveTile(Vector2 Position)
        {
            if(reservedTiels.Contains(Position))
            {
                return false;
            }
            else
            {
                reservedTiels.Add(Position);
                return true;
            }
        }

        public bool IsTileFree(Vector2 Position)
        {
            return !reservedTiels.Contains(Position);
        }

        public void ReleaseTile(Vector2 Position)
        {
            reservedTiels.Remove(Position);
        }
    }

}
