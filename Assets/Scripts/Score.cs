using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    
    private static int score;
    private static int distance;

    void Start()
    {       
        score = 0;
        distance = 0;
    }

    private void Update()
    {
        distance = (int)(transform.position.x + 8.5f);
    }

    public static void IncrementScore(int points = 1)
    {
        score += points;
    }
    public static int GetScore()
    {
        return score;
    }

    public static int GetDistance()
    {
        return distance;
    }

    public static void CheckIfHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public static void CheckIfBestDistance()
    {
        if (PlayerPrefs.HasKey("BestDistance"))
        {
            if (PlayerPrefs.GetInt("BestDistance") < distance)
            {
                PlayerPrefs.SetInt("BestDistance", distance);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestDistance", distance);
        }
    }
    public static void ResetScore()
    {
        score = 0;
    }
    public static void ResetDistance()
    {
        distance = 0;
    }
    public static void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}