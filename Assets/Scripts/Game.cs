using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Game : MonoBehaviour
{
    public UI Ui;
    public bool isGameRunning = false;

    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.ShowStartScreenPanel();
        Ui.SetScoreText("Score: " + ScoreKeeper.GetScore());
    }

    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        print("OnStartButtonClicked");
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
