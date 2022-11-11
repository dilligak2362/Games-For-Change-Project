using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{ 
<<<<<<< Updated upstream

    public int damage; 
    public ScoreManager scoreManager; 
=======
    public bool dmg_trigger;
    public int damage;
    public ScoreManager scoreManager;
>>>>>>> Stashed changes

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.tag== "Player")
    {
        scoreManager.ScoreChange(damage);
    }
}
}
