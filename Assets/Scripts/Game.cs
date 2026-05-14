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

    private int difficulty = 0;
    
    private void Awake()
    {
        PlayerHealth = FindObjectOfType<PlayerHealth>();
    }
    
    void Start()
    {
        Ui.HideGameOverScreenPanel();
        Ui.HideUiPanel();
        Ui.ShowStartScreenPanel();
        Ui.SetScoreText("Score: " + ScoreKeeper.GetScore());
        Ui.ResetHealth();
    }

    void Update()
    {
         if (PlayerHealth.GetHealth() == 0)
         {
             EndGame();
         }

         if (ScoreKeeper.GetScore() % 10 == 0 && ScoreKeeper.GetScore() >= 10)
         {
             IncreaseDifficulty();
         }
    }

    private void IncreaseDifficulty()
    {
        if (ScoreKeeper.GetScore() >= 50)
        {
            difficulty = 5;
        }
        else if (ScoreKeeper.GetScore() >= 40)
        {
            difficulty = 4;
        }
        else if (ScoreKeeper.GetScore() >= 30)
        {
            difficulty = 3;
        }
        else if (ScoreKeeper.GetScore() >= 20)
        {
            difficulty = 2;
        }
        else if (ScoreKeeper.GetScore() >= 10)
        {
            difficulty = 1;
        }
        else difficulty = 0;
        SpecialBirdSpawner.UpdateAvailableSpecialBirds(difficulty);
        print("Increase difficulty: " + difficulty);
    }

    private void EndGame()
    {
        isGameRunning = false;
        StopPlacers();
        Ui.ShowGameOverScreenPanel();
        Ui.HideStartScreenPanel();
        Ui.HideUiPanel();
        //Player.gameObject.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        StartGame();
    }

    private void StartGame()
    {
        difficulty = 0;
        InitializeGame();
        Ui.HideStartScreenPanel();
        Ui.HideGameOverScreenPanel();
        Ui.ShowUiPanel();
    }

    public void OnPlayAgainButtonClicked()
    {
        StartGame();
    }

    public void InitializeGame()
    {
        isGameRunning = true;
        Player.transform.position = new Vector3(0.41f, -3.8f, 0f);
        StartPlacers();
        PlayerHealth.Reset();
        Ui.ResetScore();
        Ui.ResetHealth();
        //Player.gameObject.SetActive(true);
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
