using UnityEngine;

public class GameEntitiesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mazeExitPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int enemiesAmount;

    private void Awake() => EventsHandler.MazeGenerated.AddListener(SpawnEntities);

    private void SpawnEntities(MazeCell[,] grid)
    {
        SpawnMazeExit(grid);

        for (int i = 0; i < enemiesAmount; i++)
        {
            SpawnEnemy(grid);
        }
    }

    private void SpawnEnemy(MazeCell[,] grid)
    {
        int offsetFromPlayerCorner = 1;

        int startRandomW = Random.Range(offsetFromPlayerCorner, grid.GetUpperBound(0));
        int startRandomD = Random.Range(offsetFromPlayerCorner, grid.GetUpperBound(1));

        int endRandomW = Random.Range(offsetFromPlayerCorner, grid.GetUpperBound(0));
        int endRandomD = Random.Range(offsetFromPlayerCorner, grid.GetUpperBound(1));

        Transform startPathPosition = grid[startRandomW, startRandomD].transform;
        Transform endPathPosition = grid[endRandomW, endRandomD].transform;

        if (startPathPosition == endPathPosition)
            return;

        var enemy = Instantiate(enemyPrefab, startPathPosition.position, Quaternion.identity);

        var movementComponent = enemy.GetComponent<EnemyMovement>();

        movementComponent.startPosition = startPathPosition;
        movementComponent.endPosition = endPathPosition;
    }

    private void SpawnMazeExit(MazeCell[,] grid)
    {
        var lastCell = grid[grid.GetUpperBound(0), grid.GetUpperBound(1)];

        var exit = Instantiate(mazeExitPrefab, lastCell.transform);

        exit.AddComponent<MazeExit>();
    }
}
