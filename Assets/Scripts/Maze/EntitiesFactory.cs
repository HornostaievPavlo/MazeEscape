using UnityEngine;

public class EntitiesFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject mazeExitPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int enemiesAmount;

    [SerializeField]
    private GameObject playerPrefab;

    private void Awake() => EventsHandler.MazeGenerated.AddListener(CreateEntities);

    public void CreateEntities(MazeCell[,] grid)
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            SpawnEnemy(grid);
        }

        SpawnPlayer();

        SpawnMazeExit(grid);
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

    private void SpawnPlayer() => Instantiate(playerPrefab);

    private void SpawnMazeExit(MazeCell[,] grid)
    {
        var lastCell = grid[grid.GetUpperBound(0), grid.GetUpperBound(1)];

        var exit = Instantiate(mazeExitPrefab, lastCell.transform);

        exit.AddComponent<MazeExit>();
    }
}
