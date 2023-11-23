public class EntitiesSpawningState : BaseState
{
    public EntitiesSpawningState(StateHandler context) : base(context)
    {
    }

    public override void Execute()
    {
        context.entitiesFactory.CreateEntities(context.mazeGenerator.mazeGrid);

        context.SetState(context.gameActiveState);
    }
}
