using System.Collections;

public abstract class State
{
    protected StateHandler _stateHandler;

    public State(StateHandler gameStateHandler) => _stateHandler = gameStateHandler;

    public virtual IEnumerator Enter()
    {
        yield break;
    }

    public virtual IEnumerator Execute()
    {
        yield break;
    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
