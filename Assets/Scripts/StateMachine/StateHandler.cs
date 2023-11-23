using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public MazeGenerator mazeGenerator;

    public EntitiesFactory entitiesFactory;

    public BaseState currentState;

    public MazeGenerationState mazeGenerationState;
    public EntitiesSpawningState entitiesSpawningState;
    public GameActiveState gameActiveState;
    public LevelFailedState levelFailedState;
    public LevelFinishedState levelFinishedState;

    private void Start()
    {
        mazeGenerationState = new MazeGenerationState(this);
        entitiesSpawningState = new EntitiesSpawningState(this);
        gameActiveState = new GameActiveState(this);
        levelFailedState = new LevelFailedState(this);
        levelFinishedState = new LevelFinishedState(this);

        currentState = mazeGenerationState;
        StartCoroutine(currentState.Enter());
    }


    private void Update()
    {
        currentState.Execute();
    }

    public void SetState(BaseState state)
    {
        currentState = state;
        state.Enter();
    }
}
