using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private static PlayerScore _instance;

    public static PlayerScore Instance { get { return _instance; } }

    public int currentPoints { get; set; }
    public int highScore { get; set; }
    public Text points;
    
    public string file = "highs-scores.txt";
    private string message;
    public DataManager dataManager;

    public override string ToString()
    {
        return $"{base.ToString()}";
    }

    private void UpdatePoints()
    {
        points.text = currentPoints.ToString() + " points";
    }

    private void Start()
    {
        dataManager = new DataManager();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            dataManager.Save();
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
            _instance.currentPoints = 0;
            _instance.highScore = PlayerPrefs.GetInt("HighScore", 0);
            _instance.points.text = "0 points";
            _instance.message = "0 points";
            _instance.dataManager = new DataManager();
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

    void OnDestroy()
    {
        dataManager.InsertScore(currentPoints);
        dataManager.Save();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // for mobile devices
        if (pauseStatus)
            dataManager.Save();
    }
}
