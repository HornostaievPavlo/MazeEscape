using System.Collections;
using UnityEngine;

public class GameActive : State
{
    public GameActive(StateHandler gameStateHandler) : base(gameStateHandler)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log("Game started");

        yield return Execute();
    }

    public override IEnumerator Execute()
    {
        yield return Exit();
    }

    public override IEnumerator Exit()
    {
        Debug.Log("Game ended");
        yield break;
    }
}
