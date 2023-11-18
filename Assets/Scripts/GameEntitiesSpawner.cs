using UnityEngine;

public class GameEntitiesSpawner : MonoBehaviour
{
    [SerializeField]
    private MazeGenerator mazeGenerator;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject mazeExitPrefab;

    private void Awake() => EventsHandler.MazeGenerated.AddListener(SpawnEntities);

    private void SpawnEntities(MazeCell[,] grid)
    {
        SpawnPlayer();
        SpawnEnemies(grid);
        SpawnMazeExit(grid);
    }

    private void SpawnPlayer() => Instantiate(playerPrefab);

    private void SpawnEnemies(MazeCell[,] grid)
    {
        int startRandomW = Random.Range(2, grid.GetUpperBound(0));
        int startRandomD = Random.Range(2, grid.GetUpperBound(1));

        int endRandomW = Random.Range(2, grid.GetUpperBound(0));
        int endRandomD = Random.Range(2, grid.GetUpperBound(1));

        Transform startPathPosition = grid[startRandomW, startRandomD].transform;
        Debug.Log(startPathPosition);

        Transform endPathPosition = grid[endRandomW, endRandomD].transform;
        Debug.Log(endPathPosition);

        var enemy = Instantiate(enemyPrefab, startPathPosition.position, Quaternion.identity);

        enemy.GetComponent<EnemyMovement>().PathStartPosition = startPathPosition;
        enemy.GetComponent<EnemyMovement>().PathEndPosition = endPathPosition;
    }

    private void SpawnMazeExit(MazeCell[,] grid)
    {
        var lastCell = grid[grid.GetUpperBound(0), grid.GetUpperBound(1)];

        Instantiate(mazeExitPrefab, lastCell.transform);
    }
}
