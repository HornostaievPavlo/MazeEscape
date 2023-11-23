using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent PlayerKilled = new UnityEvent();

    public static UnityEvent LevelFinished = new UnityEvent();

    public static void OnPlayerKilled() => PlayerKilled.Invoke();

    public static void OnLevelFinished() => LevelFinished.Invoke();
}
