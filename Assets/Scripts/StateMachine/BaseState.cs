using System.Collections;

public abstract class BaseState
{
    protected StateHandler context;

    public BaseState(StateHandler context)
    {
        this.context = context;
    }

    public virtual IEnumerator Enter()
    {
        yield break;
    }

    public virtual void Execute()
    {
    }

    public virtual void Exit()
    {
    }
}
