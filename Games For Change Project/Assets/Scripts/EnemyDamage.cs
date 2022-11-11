using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{ 

    public int damage; 
    public ScoreManager scoreManager; 

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.tag== "Player")
    {
        scoreManager.ScoreChange(damage);
    }
}
}
