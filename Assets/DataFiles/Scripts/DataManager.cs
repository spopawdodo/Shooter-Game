using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    private static DataManager _instance;
    public static DataManager Instance { get { return _instance; } }
    
    private string filename = "highs-scores.txt";
    public Player player;

    public DataManager()
    {
        string path = GetFilePath(filename);
        if (File.Exists(path))
        {
            Load();
        }
        else
        {
            this.player = new Player();
        }
        
    }

    public int GetScore(int pos)
    {
        return player.getScore(pos);
    }
    
    public void InsertScore(int score)
    {
        this.player.insertScore(score);
    }

    public string GetPlayerName()
    {
        return this.player.Name;
    } 
    
    public int GetCapacity()
    {
        return this.player.getCapacity();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(player);
        WriteToFile(filename, json);
    }

    public void Load()
    {
        player = new Player();
        string json = ReadFromFile(filename);
        JsonUtility.FromJsonOverwrite(json, player);
    }

    private void WriteToFile(string filename, string json)
    {
        string path = GetFilePath(filename);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string filename)
    {
        string path = GetFilePath(filename);

        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();

                return json;
            }
        } else 
            Debug.LogWarning("Fatal error! File not found!");

        return "";

    }
    
    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + '/' + filename;
    }
}

public class Player
{
    private string playerName;
    public List<int> highscores;

    public Player()
    {
        this.playerName = "Current Player";
        this.highscores = new List<int>();
    }
    
    public string Name { get { return playerName; } set { playerName = value; } }

    public int getScore(int pos)
    {
        return this.highscores[pos];
    }
    
    public void insertScore(int score)
    {
        this.highscores.Sort((a, b) => b.CompareTo(a));
        if (getCapacity() >= 5)
        {
            if (this.highscores[getCapacity() - 1] < score)
            {
                this.highscores[getCapacity() - 1] = score;    
            }
            this.highscores = this.highscores.GetRange(0, 5);
        }
        else
        {
            this.highscores.Add(score);    
        }
        
        this.highscores.Sort((a, b) => b.CompareTo(a));
    }

    public int getCapacity()
    {
        return this.highscores.Count;
    }
}
