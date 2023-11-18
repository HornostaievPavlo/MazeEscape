using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<MazeCell[,]> MazeGenerated = new UnityEvent<MazeCell[,]>();

    public static void OnMazeGenerated(MazeCell[,] grid)
    {
        MazeGenerated.Invoke(grid);
    }
}
