using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    [SerializeField] private int HP=10;
    [SerializeField] private int Damage;
    [SerializeField] private int MaxHP=10;
    public static bool canmove=true;
    public static int current;
    [SerializeField] private Text Lives;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        Lives.text = "Lives: " + current;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        current = currentHP();
        HP = current;
        Lives.text = "Lives: " + current;
        if(current <= 0)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            canmove = false;
            HP -= Damage;
            if (PlayerMovement.input>0)
            {
                PlayerMovement.rb.AddForce(Vector2.left * 70, ForceMode2D.Impulse);
            }
            else PlayerMovement.rb.AddForce(Vector2.right * 70, ForceMode2D.Impulse);
            if (HP <= 0)
            {
                
                Lives.text = "Lives: " + HP;
               
               
            }

        }
        else
        {
            canmove=true;
        }
    }
    public int currentHP()
    {
        Debug.Log(HP);
        return HP;
    }
}
