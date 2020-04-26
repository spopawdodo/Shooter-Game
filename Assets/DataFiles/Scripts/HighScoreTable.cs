using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    private Transform entryTemplate;
    private DataManager _dataManager;
    

    private void Awake()
    {
        _dataManager = new DataManager();
        entryTemplate = entryContainer.Find("ScoreEntryTemplate");
        
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        
        for (int i = 0; i < _dataManager.GetCapacity(); i++)
        {
            int rank = i + 1;
            string rankString;
            
            switch (rank)
            {
                default:
                    rankString = rank + "th";
                    break;
                case 1:
                    rankString = "1st";
                    break;
                case 2:
                    rankString = "2nd";
                    break;
                case 3:
                    rankString = "3rd";
                    break;
            }

            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = _dataManager.GetPlayerName();
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = _dataManager.GetScore(i).ToString();

            entryRectTransform.anchoredPosition = new Vector3(0, -templateHeight * i, 0);
            entryTransform.gameObject.SetActive(true);
        }
        
    }
}
