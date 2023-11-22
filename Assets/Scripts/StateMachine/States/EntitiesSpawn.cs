using System.Collections;

public class EntitiesSpawn : State
{
    public EntitiesSpawn(StateHandler stateHandler) : base(stateHandler)
    {
    }

    public override IEnumerator Enter()
    {
        yield return Execute();
    }

    public override IEnumerator Execute()
    {
        var grid = _stateHandler.mazeGenerator.mazeGrid;
        _stateHandler.entitiesFactory.CreateEntities(grid);

        _stateHandler.SetState(new GameActive(_stateHandler));
        yield break;
    }
}
