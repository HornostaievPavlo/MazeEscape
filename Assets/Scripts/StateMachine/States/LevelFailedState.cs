using System.Collections;
using UnityEngine;

public class LevelFailedState : BaseState
{
    public LevelFailedState(StateHandler context) : base(context)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log("Level Failed");
        return base.Enter();
    }
}
