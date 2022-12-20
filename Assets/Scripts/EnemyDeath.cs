using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public static int addscore=0;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            AddScore();
            
            
        }
    }
    public int AddScore()
    {

        return ScoreScript.ScoreInt+=2;
    }
}
