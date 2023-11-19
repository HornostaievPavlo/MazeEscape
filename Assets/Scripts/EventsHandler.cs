using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<MazeCell[,]> MazeGenerated = new UnityEvent<MazeCell[,]>();

    public static UnityEvent<int> PlayerDamaged = new UnityEvent<int>();

    public static UnityEvent LevelFinished = new UnityEvent();

    public static void OnMazeGenerated(MazeCell[,] grid) => MazeGenerated.Invoke(grid);

    public static void OnPlayerDamaged(int damage) => PlayerDamaged.Invoke(damage);

    public static void OnLevelFinished() => LevelFinished.Invoke();
}
