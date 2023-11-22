public class StateHandler : StateMachine
{
    public MazeGenerator mazeGenerator;

    private void Start()
    {
        SetState(new MazeGeneration(this));
    }
}
