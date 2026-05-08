using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Game : MonoBehaviour
{
    public UI Ui;
    private bool isGameRunning = false;
    public BirdSpawner BirdSpawner;
    private Health health;
    
    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.ShowStartScreenPanel();
        Ui.SetScoreText("Score: " + ScoreKeeper.GetScore());
        Ui.ResetHealth();
    }

    void Update()
    {
        /* if (Health.currentHealth == 0)
        {
            isGameRunning = false;
            Ui.ShowGameOverScreenPanel();
        }
        */
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
        StartPlacers();
        Ui.ResetScore();
        Ui.ResetHealth();
    }

    private void StartPlacers()
    {
        BirdSpawner.StartPlacing();
    }

    private void StopPlacers()
    {
        BirdSpawner.StopPlacing();
    }
    public bool IsGameRunning()
    {
        return isGameRunning;
    }
    
}
