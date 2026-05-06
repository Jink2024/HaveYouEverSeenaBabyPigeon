using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public bool isGameRunning = false;

    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.ShowStartScreenPanel();
    }

    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        Ui.HideStartScreenPanel();
        InitializeGame();
    }

    public void OnPlayAgainButtonClicked()
    {
        Ui.HideGameOverScreenPanel();
        InitializeGame();
    }

    public void InitializeGame()
    {
        isGameRunning = true;
        ScoreKeeper.ResetScore();
        Ui.ResetScore();
    }

}
