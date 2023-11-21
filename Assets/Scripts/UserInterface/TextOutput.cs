using TMPro;
using UnityEngine;

public class TextOutput : MonoBehaviour
{
    private TMP_Text mainText;

    private void Start()
    {
        mainText = GetComponent<TMP_Text>();

        EventsHandler.MazeGenerated.AddListener(DisplayMazeSize);
        EventsHandler.LevelFinished.AddListener(DisplayWinMessage);
        EventsHandler.PlayerKilled.AddListener(DisplayGameOverMessage);
    }

    private void DisplayMazeSize(MazeCell[,] grid)
    {
        int width = grid.GetUpperBound(0) + 1;
        int depth = grid.GetUpperBound(1) + 1;

        string output = $"Maze dimensions - {width} x {depth}";
        mainText.text = output;
    }

    private void DisplayWinMessage()
    {
        string message = "Level finished";
        mainText.text = message;
    }

    private void DisplayGameOverMessage()
    {
        string message = "Game over";
        mainText.text = message;
    }
}
