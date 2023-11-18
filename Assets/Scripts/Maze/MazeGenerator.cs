using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell cellPrefab;

    [SerializeField]
    private int totalWidth;

    [SerializeField]
    private int totalDepth;

    private MazeCell[,] mazeGrid;

    private IEnumerator Start()
    {
        PopulateGridWithCells();

        var firstCell = mazeGrid[0, 0];
        yield return GenerateMaze(null, firstCell);
    }

    private void PopulateGridWithCells()
    {
        mazeGrid = new MazeCell[totalWidth, totalDepth];

        for (int i = 0; i < totalWidth; i++)
        {
            for (int j = 0; j < totalDepth; j++)
            {
                var currentCellPosition = new Vector3(i, 0, j);
                mazeGrid[i, j] = Instantiate(cellPrefab, currentCellPosition, Quaternion.identity);
                mazeGrid[i, j].name = $"Row {i}, Column {j}";
            }
        }
    }

    private IEnumerator GenerateMaze(MazeCell previous, MazeCell current)
    {
        current.Visit();

        RemoveWalls(previous, current);
        yield return new WaitForEndOfFrame();

        MazeCell nextCell;

        do
        {
            nextCell = FindNextUnvisitedCell(current);

            if (nextCell != null)
            {
                yield return GenerateMaze(current, nextCell);
            }
        }
        while (nextCell != null);
    }

    private MazeCell FindNextUnvisitedCell(MazeCell current)
    {
        var unvisitedCells = FindAllUnvisitedCells(current);

        return unvisitedCells.OrderBy(cell => Random.Range(1f, 10f)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> FindAllUnvisitedCells(MazeCell current)
    {
        int xPos = (int)current.transform.position.x;
        int zPos = (int)current.transform.position.z;

        int cellToRightPos = xPos + 1;
        int cellToLeftPos = xPos - 1;

        int cellToFrontPos = zPos + 1;
        int cellToBackPos = zPos - 1;

        if (cellToRightPos < totalWidth)
        {
            var cellToRight = mazeGrid[cellToRightPos, zPos];

            if (cellToRight.IsCellVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (cellToLeftPos >= 0)
        {
            var cellToLeft = mazeGrid[cellToLeftPos, zPos];

            if (cellToLeft.IsCellVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (cellToFrontPos < totalDepth)
        {
            var cellToFront = mazeGrid[xPos, cellToFrontPos];

            if (cellToFront.IsCellVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (cellToBackPos >= 0)
        {
            var cellToBack = mazeGrid[xPos, cellToBackPos];

            if (cellToBack.IsCellVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void RemoveWalls(MazeCell previous, MazeCell current)
    {
        if (previous == null) return;

        if (previous.transform.position.x < current.transform.position.x)
        {
            previous.ClearRightWall();
            current.ClearLeftWall();
            return;
        }

        if (previous.transform.position.x > current.transform.position.x)
        {
            previous.ClearLeftWall();
            current.ClearRightWall();
            return;
        }

        if (previous.transform.position.z < current.transform.position.z)
        {
            previous.ClearFrontWall();
            current.ClearBackWall();
            return;
        }

        if (previous.transform.position.z > current.transform.position.z)
        {
            previous.ClearBackWall();
            current.ClearFrontWall();
            return;
        }
    }
}
