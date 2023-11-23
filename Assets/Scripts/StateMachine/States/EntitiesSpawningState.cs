using System.Collections;

public class EntitiesSpawningState : BaseState
{
    public EntitiesSpawningState(StateHandler context) : base(context)
    {
    }

    public override IEnumerator Enter()
    {
        return base.Enter();
    }

    public override void Execute()
    {
        context.entitiesFactory.CreateEntities(context.mazeGenerator.mazeGrid);

        context.SetState(context.gameActiveState);
    }

    public override void Exit()
    {
        context.healthBar.AssignPlayerToHealthBar();
    }
}
