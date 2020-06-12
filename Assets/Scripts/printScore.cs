using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class printScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    void Start()
    {        
        scoreText.SetText("Score: 0");
        if (!PlayerPrefs.HasKey("HighScore"))
            highScoreText.SetText("High score: 0");
        else
            highScoreText.SetText("High score: " + PlayerPrefs.GetInt("HighScore").ToString());
    }

    void Update()
    {
        Score.CheckIfHighScore();
        scoreText.SetText("Score: " + Score.GetScore().ToString());
        highScoreText.SetText("High score: " + PlayerPrefs.GetInt("HighScore").ToString());
    }

}
