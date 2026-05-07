using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Game : MonoBehaviour
{
    public UI Ui;
    private bool isGameRunning = false;
    public BirdSpawner BirdSpawner;
    
    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.ShowStartScreenPanel();
        // Ui.SetScoreText("Score: " + ScoreKeeper.GetScore());
        Ui.ResetHealth();
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
        StartPlacers();
        //ScoreKeeper.ResetScore();
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
