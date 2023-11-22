using System.Collections;

public class MazeGeneration : State
{
    public MazeGeneration(StateHandler gameStateHandler) : base(gameStateHandler)
    {
    }

    public override IEnumerator Enter()
    {
        return Execute();
    }

    public override IEnumerator Execute()
    {
        yield return _stateHandler.mazeGenerator.Generate();

        _stateHandler.SetState(new EntitiesSpawning(_stateHandler));
    }
}
