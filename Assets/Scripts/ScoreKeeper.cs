using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;
    private static TextMeshPro scoreTextMeshPro;
    
    public static void AddPoint()
    {
        score++;
    }
    
    public static void ResetScore()
    {
        score = 0;
    }
    
    public static int GetScore()
    {
        return score;
    }
    
    public static string GetScoreAsString()
    {
        return score.ToString();
    }
}