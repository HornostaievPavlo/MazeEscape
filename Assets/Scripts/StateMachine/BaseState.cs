using System.Collections;

public abstract class BaseState
{
    public virtual IEnumerator Enter(StateHandler stateHandler)
    {
        yield break;
    }

    public virtual IEnumerator Execute(StateHandler stateHandler)
    {
        yield break;
    }

    public virtual IEnumerator Exit(StateHandler stateHandler)
    {
        yield break;
    }
}
