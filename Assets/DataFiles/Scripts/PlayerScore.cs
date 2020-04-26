using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private static PlayerScore _instance;

    public static PlayerScore Instance { get { return _instance; } }

    public int currentPoints { get; set; }
    public int highScore { get; set; }
    public Text points;

    private void UpdatePoints()
    {
        points.text = currentPoints.ToString() + " points";
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
            _instance.currentPoints = 0;
            _instance.highScore = PlayerPrefs.GetInt("HighScore", 0);
            _instance.points.text = "0 points";
        }
    }

    public void DecreasePoints(int points = 3)
    {
        currentPoints -= points;
        UpdatePoints();
    }

    public void AddPoints(int points = 1)
    {
        currentPoints += points;
        UpdatePoints();
    }

    public void UpdateHighScore()
    {
        if (currentPoints > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore",currentPoints);
            highScore = currentPoints;
            PlayerPrefs.SetString("LastScore","New high score!\n" + currentPoints.ToString() + " points");
        }
        else
        {
            PlayerPrefs.SetString("LastScore", currentPoints.ToString() + " points\n High Score :" + highScore.ToString());
        }
    }
}
