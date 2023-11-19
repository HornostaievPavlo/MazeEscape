using UnityEngine;
using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<MazeCell[,]> MazeGenerated = new UnityEvent<MazeCell[,]>();

    public static UnityEvent<float> PlayerDamaged = new UnityEvent<float>();

    public static UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();

    public static UnityEvent<Transform> PlayerGotInSight = new UnityEvent<Transform>();

    public static UnityEvent PlayerLostFromSight = new UnityEvent();

    public static UnityEvent PlayerKilled = new UnityEvent();

    public static UnityEvent LevelFinished = new UnityEvent();

    public static void OnMazeGenerated(MazeCell[,] grid) => MazeGenerated.Invoke(grid);

    public static void OnPlayerDamaged(float damage) => PlayerDamaged.Invoke(damage);

    public static void OnPlayerHealthUpdated(float changePercent) => PlayerHealthUpdated.Invoke(changePercent);

    public static void OnPlayerGotInSight(Transform player) => PlayerGotInSight.Invoke(player);

    public static void OnPlayerLostFromSight() => PlayerLostFromSight.Invoke();

    public static void OnPlayerKilled() => PlayerKilled.Invoke();

    public static void OnLevelFinished() => LevelFinished.Invoke();
}
