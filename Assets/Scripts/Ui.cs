using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public CanvasGroup StartScreenPanelCanvasGroup;
    public CanvasGroup GameOverPanelCanvasGroup;
    public CanvasGroup UiPanelCanvasGroup;
    
    public void SetScoreText(string score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetHealthText(string health)
    {
        //healthText.text = $"Health: {health}/10";
    }

    public void ResetHealth()
    {
        healthText.text = "Health: 10/10";
    }

    public void ResetScore()
    {
        scoreText.text = "Score: 0";
    }

    public void HideStartScreenPanel()
    {
        CanvasGroupDisplayer.Hide(StartScreenPanelCanvasGroup);
    }

    public void HideGameOverScreenPanel()
    {
        CanvasGroupDisplayer.Hide(GameOverPanelCanvasGroup);
    }
    
    public void ShowGameOverScreenPanel()
    {
        CanvasGroupDisplayer.Show(GameOverPanelCanvasGroup);
    }
    
    public void ShowStartScreenPanel()
    {
        CanvasGroupDisplayer.Show(StartScreenPanelCanvasGroup);
    }
    
    public void ShowUiPanel()
    {
        CanvasGroupDisplayer.Show(UiPanelCanvasGroup);
    }
    
    public void HideUiPanel()
    {
        CanvasGroupDisplayer.Hide(UiPanelCanvasGroup);
    }
}