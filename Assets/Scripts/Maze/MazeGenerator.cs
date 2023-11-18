using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell cellPrefab;

    [SerializeField]
    private int width;

    [SerializeField]
    private int depth;

    private MazeCell[,] mazeGrid;

    private void Start()
    {
        PopulateGridWithCells();
    }

    private void PopulateGridWithCells()
    {
        mazeGrid = new MazeCell[width, depth];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                var currentCellPosition = new Vector3(i, 0, j);
                mazeGrid[i, j] = Instantiate(cellPrefab, currentCellPosition, Quaternion.identity);
            }
        }
    }
}
