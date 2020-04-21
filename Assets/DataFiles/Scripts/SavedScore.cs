using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedScore : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = PlayerPrefs.GetString("LastScore", "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
