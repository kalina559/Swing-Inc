using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class printDistance : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestDistanceText;
    void Start()
    {
        scoreText.SetText("Distance: 0 m");
        if (!PlayerPrefs.HasKey("BestDistance"))
            bestDistanceText.SetText("Best: 0 m");
        else
            bestDistanceText.SetText("Best: " + PlayerPrefs.GetInt("BestDistance").ToString() + " m");
    }

    void Update()
    {
        Score.CheckIfBestDistance();
        scoreText.SetText("Distance: " + Score.GetDistance().ToString() + " m");
        bestDistanceText.SetText("Best: " + PlayerPrefs.GetInt("BestDistance").ToString() + " m");
    }

}
