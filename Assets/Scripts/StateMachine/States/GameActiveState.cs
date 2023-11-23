using System.Collections;

public class GameActiveState : BaseState
{
    public GameActiveState(StateHandler context) : base(context)
    {
    }

    public override IEnumerator Enter()
    {
        EventsHandler.LevelFinished.AddListener(OnLevelFinished);
        EventsHandler.PlayerKilled.AddListener(OnLevelFailed);

        return base.Enter();
    }

    private void OnLevelFinished()
    {
        context.SetState(context.levelFinishedState);
    }

    private void OnLevelFailed()
    {
        context.SetState(context.levelFailedState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
