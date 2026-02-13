using System.Numerics;
using System.Runtime.CompilerServices;
using Game.Core;
using Game.Utilities;
using Godot;
using Vector2 = Godot.Vector2;

namespace Game.Gameplay;

public partial class NPCRoam : State
{
    [ExportCategory("State Variables")]
    [Export]
    public NPCInput NPCInput;
    [Export]
    public CharacterMovement CharacterMovement;

    private double timer = 2f;

    public override void _Process(double delta)
    {
        if(CharacterMovement.IsMoving())
        return;
        switch (NPCInput.Config.NpcMoveType)
        {
            case NpcMoveType.Wander:
                HandleWander(delta, NPCInput.Config.WanderMoveInterval);
                break;
            case NpcMoveType.LookAround:
                HandleLook(delta, NPCInput.Config.LookAroundInterval);
                break;
        }
    }

    private void HandleWander(double delta, double interval)
    {
        timer -= delta;
        if(timer > 0)
        return;

        var (direction, targetPosition) = GetNewDirection();

        NPCInput.Direction = direction;
        NPCInput.TargetPosition = targetPosition;

        NPCInput.EmitSignal(CharacterInput.SignalName.Walk);
        timer = interval;
    }

        private void HandleLook(double delta, double interval)
    {
        timer -= delta;
        if(timer > 0)
        return;

        var (direction, targetPosition) = GetNewDirection();

        if(direction == NPCInput.Direction)
        {
            timer = interval;
            return;
        }

        NPCInput.Direction = direction;
        NPCInput.TargetPosition = targetPosition;

        NPCInput.EmitSignal(CharacterInput.SignalName.Turn);
        timer = interval;
    }

    private (Vector2, Vector2) GetNewDirection()
    {
        Vector2[] directions = [Vector2.Left,Vector2.Right,Vector2.Up,Vector2.Down];
        Vector2 chosenDirection;

        int tries = 0;

        do
        {
            chosenDirection = directions[Globals.GetRandomNumberGenerator().RandiRange(0, directions.Length - 1)];
            Vector2 nextPosition = CharacterMovement.Character.Position + chosenDirection * Globals.GRID_SIZE;

            if(NPCInput.Config.NpcMoveType == NpcMoveType.Wander)
            {
                float distanceFromOriginm = nextPosition.DistanceTo(NPCInput.Config.WanderOrigin);
                if(distanceFromOriginm <= NPCInput.Config.WanderRadius)
                    break;
            }
            else
            {
                break;
            }
            tries++;
        } while(tries < 10);    
        return (chosenDirection, chosenDirection * Globals.GRID_SIZE);
}
}