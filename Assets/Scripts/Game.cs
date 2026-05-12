using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Game : MonoBehaviour
{
    public UI Ui;
    private bool isGameRunning = false;
    public BirdSpawner BirdSpawner;
    public SpecialBirdSpawner SpecialBirdSpawner;
    private PlayerHealth PlayerHealth;
    public Player Player;
    
    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.HideUiPanel();
        Ui.ShowStartScreenPanel();
        Ui.ResetHealth();
        if (PlayerHealth.currentHealth == 0)
        {
            EndGame();
        }
    }

    void Update()
    {
        
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