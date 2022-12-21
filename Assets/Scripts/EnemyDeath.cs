using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    public static int addscore=0;
    public static bool die;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
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
    public void Death()
    {
        animator.SetBool("IsHit",false);
        
    }
}
