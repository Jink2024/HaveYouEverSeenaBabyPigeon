using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Game : MonoBehaviour
{
    public UI Ui;
    private bool isGameRunning = false;
    public BirdSpawner BirdSpawner;
    public SpecialBirdSpawner SpecialBirdSpawner;
    // public BirdSpawner GooseSpawner;
    private PlayerHealth PlayerHealth;
    public Player Player;
    
    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.ShowStartScreenPanel();
        Ui.SetScoreText("Score: " + ScoreKeeper.GetScore());
        Ui.ResetHealth();
        PlayerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
         if (PlayerHealth.GetHealth() == 0)
         {
             EndGame();
         }
        
    }

    private void EndGame()
    {
        isGameRunning = false;
        StopPlacers();
        Ui.ShowGameOverScreenPanel();
        Ui.HideStartScreenPanel();
        Ui.HideUiPanel();
        Player.gameObject.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        StartGame();
    }

    private void StartGame()
    {
        Ui.HideStartScreenPanel();
        Ui.HideGameOverScreenPanel();
        Ui.ShowUiPanel();
        InitializeGame();
    }

    public void OnPlayAgainButtonClicked()
    {
        StartGame();
    }

    public void InitializeGame()
    {
        isGameRunning = true;
        StartPlacers();
        PlayerHealth.Reset();
        Ui.ResetScore();
        Ui.ResetHealth();
        Player.gameObject.SetActive(true);
    }

    private void StartPlacers()
    {
        BirdSpawner.StartPlacing();
        SpecialBirdSpawner.StartPlacing();
        // GooseSpawner.StartPlacing();
    }

    private void StopPlacers()
    {
        BirdSpawner.StopPlacing();
        SpecialBirdSpawner.StopPlacing();
        // GooseSpawner.StopPlacing();
    }
    public bool IsGameRunning()
    {
        return isGameRunning;
    }
    
}
