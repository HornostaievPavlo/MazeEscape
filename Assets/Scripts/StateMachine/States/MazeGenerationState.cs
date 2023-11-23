using System.Collections;

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

    public override void Exit()
    {
        base.Exit();
    }
}
