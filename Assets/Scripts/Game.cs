using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Game : MonoBehaviour
{
    public UI Ui;
    private bool isGameRunning = false;
    public BirdSpawner BirdSpawner;
    public SpecialBirdSpawner SpecialBirdSpawner;
    
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
        StartPlacers();
        ScoreKeeper.ResetScore();
        Ui.ResetScore();
    }

    private void StartPlacers()
    {
        BirdSpawner.StartPlacing();
        SpecialBirdSpawner.StartPlacing();
    }

    private void StopPlacers()
    {
        BirdSpawner.StopPlacing();
        SpecialBirdSpawner.StopPlacing();
    }
    public bool IsGameRunning()
    {
        return isGameRunning;
    }
}
