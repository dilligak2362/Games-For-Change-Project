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
    public GameObject Coin;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }

        uiObject.SetActive(false);
        Coin.SetActive(false); 

        
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

    public void ScoreChange(int damage)
    {
        score -= damage;
        text.text = "X" + score.ToString();

        if (score <= 0)
        {
            Coin.SetActive(true);
            uiObject.SetActive(false);
        }
    }
    
}
