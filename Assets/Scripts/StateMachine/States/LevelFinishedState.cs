using System.Collections;
using UnityEngine;

public class LevelFinishedState : BaseState
{
    public LevelFinishedState(StateHandler context) : base(context)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log("Level Finished");
        return base.Enter();
    }
}
