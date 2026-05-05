using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text scoreText;
    public CanvasGroup StartScreenPanelCanvasGroup;
    public CanvasGroup GameOverPanelCanvasGroup;
    
    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
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
    
}