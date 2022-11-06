using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }

        uiObject.SetActive(false);

        
    }

    
    
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();

        if (score == 1)
        {
            uiObject.SetActive(true);
        }
    }
    
}
