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
<<<<<<< Updated upstream
    public GameObject Coin;
    public GameObject Wall; 
=======
    public GameObject SoulOne;
    public GameObject SoulTwo;
    public GameObject SoulThree;
    public GameObject Wall;
    public GameObject TallWall;
    public EnemyDamage enemy;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }

        uiObject.SetActive(false);
<<<<<<< Updated upstream
        Coin.SetActive(false);
        Wall.SetActive(true);
=======
        
>>>>>>> Stashed changes

        
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
        else
        {
            Wall.SetActive(true);
        }
    }

    public void ScoreChange(int damage)
    {
        score -= damage;
        text.text = "X" + score.ToString();

        if (score <= 0)
        {
<<<<<<< Updated upstream
            Coin.SetActive(true);
            uiObject.SetActive(false);
        }
=======
            score = 0; 
        }

        if (score < 3)
        { 
            SoulOne.SetActive(true);
            SoulTwo.SetActive(true);
            SoulThree.SetActive(true);
            uiObject.SetActive(false);
        }

        if (score == 3)
        {
            TallWall.SetActive(false);
        }
        else
        {
            TallWall.SetActive(true);
        }

        


        Debug.Log(score.ToString());
        
>>>>>>> Stashed changes
    }

    
}
