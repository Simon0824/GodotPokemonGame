 using Godot;
using System;
using System.Runtime.CompilerServices;

namespace Game.Core
{
    public partial class Signals : Node
    {
        public static Signals Instance { get; private set; }

        [Signal] public delegate void MessageBoxOpenEventHandler(bool value);

        public override void _Ready()
        {
            Instance = this;

            Logger.Debug("Loading Global Signals ...");
        }

        public static void EmitGlobalSignals(StringName signal, params Variant[] args)
        {
            Logger.Info("Global signal emitted: ", signal, args);
            Instance.EmitSignal(signal, args);
        }
    }

}