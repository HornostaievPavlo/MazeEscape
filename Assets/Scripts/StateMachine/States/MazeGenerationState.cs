using System;
using System.Collections;
using UnityEngine;

public class MazeGenerationState : BaseState
{
    public override IEnumerator Enter(StateHandler stateHandler)
    {
        Debug.Log("Entered maze");
        yield return stateHandler.mazeGenerator.Generate();
    }
}
