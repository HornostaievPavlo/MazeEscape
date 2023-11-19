using TMPro;
using UnityEngine;

public class TextOutput : MonoBehaviour
{
    private TMP_Text mainText;

    private void Start()
    {
        mainText = GetComponent<TMP_Text>();

        EventsHandler.MazeGenerated.AddListener(DisplayGameStart);
        EventsHandler.PlayerKilled.AddListener(DisplayGameOver);
        EventsHandler.LevelFinished.AddListener(DisplayWin);
    }
    private void DisplayGameStart(MazeCell[,] grid)
    {
        int width = grid.GetUpperBound(0) + 1;
        int depth = grid.GetUpperBound(1) + 1;

        string output = $"Maze dimensions - {width} x {depth}";
        mainText.text = output;
    }

    private void DisplayWin()
    {
        string output = "Level finished";
        mainText.text = output;
    }

    private void DisplayGameOver()
    {
        string output = "Game over";
        mainText.text = output;
    }
}
