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
    public GameObject SoulOne;
    public GameObject SoulTwo;
    public GameObject SoulThree;
    public GameObject Wall;
    public EnemyDamage enemy;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }

        uiObject.SetActive(false);
        SoulOne.SetActive(false);
        SoulTwo.SetActive(false);
        SoulThree.SetActive(false);
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

        if (score < 0)
        {
            score = 0; 
        }

        if (score == 0)
        { 
            SoulOne.SetActive(true);
            uiObject.SetActive(false);
        }

        if (score == 1)
        {
            SoulTwo.SetActive(true);
            uiObject.SetActive(false);
        }

        if (score == 2)
        {
            SoulThree.SetActive(true);
            uiObject.SetActive(false);
        }
    }

    
}
