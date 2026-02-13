using Godot;
using Game.Utilities;
namespace Game.Gameplay;
using Game.Core;
public partial class NPCMessage : State
{
    public override void _Ready()
    {
        Signals.Instance.MessageBoxOpen += (value) =>
        {
            if (!value)
            {
                StateMachine.ChangeState("Roam");
            }
        };
    }
}
