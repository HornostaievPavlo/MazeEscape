public class StateHandler : StateMachine
{
    public MazeGenerator mazeGenerator;

    public EntitiesFactory entitiesFactory;

    private void Start()
    {
        SetState(new MazeGeneration(this));
    }
}
