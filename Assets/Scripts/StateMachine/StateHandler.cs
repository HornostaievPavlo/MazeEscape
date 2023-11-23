using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public MazeGenerator mazeGenerator;

    public EntitiesFactory entitiesFactory;

    public BaseState currentState;

    public MazeGenerationState mazeGenerationState = new MazeGenerationState();
    public EntitiesSpawningState entitiesSpawningState = new EntitiesSpawningState();
    public GameActiveState gameActiveState = new GameActiveState();
    public LevelFailedState levelFailedState = new LevelFailedState();
    public LevelFinishedState levelFinishedState = new LevelFinishedState();

    private void Start()
    {
        currentState = mazeGenerationState;
        StartCoroutine(currentState.Enter(this));
    }


    private void Update()
    {
        currentState.Execute(this);
    }

    public void SetState(BaseState state)
    {
        currentState = state;
        state.Enter(this);
    }
}
