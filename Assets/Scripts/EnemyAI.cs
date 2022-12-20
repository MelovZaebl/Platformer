using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask enemy;
    private BoxCollider2D coll;
    private float dir = 2;
    private float forWallleft=1.3f;
    private float forWallright=1.3f;
    [SerializeField] private SpriteRenderer sprite;
    private Vector3 f = new Vector3(1.2f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isGround())
        {
            jump();
        }
        
        if (isLeftWall())
        {
            dir = 2;
            forWallleft = 0f;
            forWallright = 1.3f;
            sprite.flipX=false;
        }
        if(isRightWall())
        {
            Debug.Log(Physics2D.Raycast(coll.bounds.center, Vector2.right, .2f, ground));
            dir = -2;
            forWallright = 0;
            forWallleft = 1.3f;
            sprite.flipX=true;
        }

        if (dir > 0)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x + dir * Time.deltaTime, transform.position.y);
            
        }
        else
        { 
            this.gameObject.transform.position = new Vector2(transform.position.x + dir * Time.deltaTime, transform.position.y);
            
        }



    }

    private bool isLeftWall()
    {
        if (!sprite.flipX)
        {
            if (Physics2D.Raycast(coll.bounds.center + f, Vector2.left, forWallleft, enemy))
            {
                return true;
            }
            else if (Physics2D.Raycast(coll.bounds.center, Vector2.left, .5f, ground))
            {
                return true;
            }
        }
        else
        {
            if (Physics2D.Raycast(coll.bounds.center - f, Vector2.left, forWallleft, enemy))
            {
                return true;
            }
            else if (Physics2D.Raycast(coll.bounds.center, Vector2.left, .5f, ground))
            {
                return true;
            }
        }
        
       
        return false;
    }
    private bool isRightWall()
    {
        if (!sprite.flipX)
        {
            if (Physics2D.Raycast(coll.bounds.center + f, Vector2.right, forWallright, enemy))
            {
                return true;
            }
            else if (Physics2D.Raycast(coll.bounds.center, Vector2.right, .5f, ground))
            {
                return true;
            }
        }
        else
        {
            if (Physics2D.Raycast(coll.bounds.center - f, Vector2.right, forWallright, enemy))
            {
                return true;
            }
            else if (Physics2D.Raycast(coll.bounds.center, Vector2.right, .5f, ground))
            {
                return true;
            }
        }
        
        
        return false;

    }
    public void jump()
    {
        if( Physics2D.Raycast(coll.bounds.center, Vector2.right, forWallright, ground)|| Physics2D.Raycast(coll.bounds.center, Vector2.left, forWallleft, ground))
        {
            rb.AddForce(Vector2.up*2.8f, ForceMode2D.Impulse);
        }
    }
    public bool isGround()
    {
        return Physics2D.Raycast(coll.bounds.center, Vector2.down, .5f, ground);
    }

}
