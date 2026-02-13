 using Godot;
using System;
using System.Runtime.CompilerServices;

namespace Game.Core;

public partial class Globals : Node
{
    public static Globals Instance { get; private set; }
    public const int GRID_SIZE = 16;

    [Export]
    public ulong Seed = 1337;

    public RandomNumberGenerator RandomNumberGenerator;

    public override void _Ready()
    {
        Instance = this;
        RandomNumberGenerator = new()
        {
            Seed = Seed
        };
        Logger.Debug("Loading Globals ...");

    }

    public static RandomNumberGenerator GetRandomNumberGenerator()
    {
        return Instance.RandomNumberGenerator;
    }
    }