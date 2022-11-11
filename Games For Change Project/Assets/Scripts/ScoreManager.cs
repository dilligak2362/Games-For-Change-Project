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
    public GameObject Wall; 

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }

        uiObject.SetActive(false);
        Coin.SetActive(false);
        Wall.SetActive(true);

        
    }

    
    
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();

        if (score == 3)
        {
            uiObject.SetActive(true);
        }
        else
        {
            uiObject.SetActive(false); 
        }

        if (score == 2)
        {
            Wall.SetActive(false);
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
