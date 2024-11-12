using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("Score", 0);
        InvokeRepeating("IncrementScore", 0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementScore()
    {
        score++;
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("Score", score);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score >= PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}
