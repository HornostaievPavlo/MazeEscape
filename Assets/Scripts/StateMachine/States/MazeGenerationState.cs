using System;
using System.Collections;
using UnityEngine;

public class MazeGenerationState : BaseState
{
    public MazeGenerationState(StateHandler context) : base(context)
    {
    }

    public override IEnumerator Enter()
    {
        yield return context.mazeGenerator.Generate();

        context.SetState(context.entitiesSpawningState);
    }
}
