using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{ 
    public bool dmg_trigger;
    public int damage;
    public ScoreManager scoreManager; 

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.tag == "Player")
    {
        Debug.Log("Anything");
        scoreManager.ScoreChange(damage);
        dmg_trigger = true;
    }

    else if (collision.gameObject.tag != "Player")
    {
            
            dmg_trigger = false;
    }
}
}