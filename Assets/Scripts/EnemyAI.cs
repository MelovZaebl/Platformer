using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    private BoxCollider2D coll;
    private float dir = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (isLeftWall())
        {
            dir = 2;
        }
        if(isRightWall())
        {
            Debug.Log(Physics2D.Raycast(coll.bounds.center, Vector2.right, 1f, ground));
            dir = -2;
        }
       
        if (dir > 0)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x + dir * Time.deltaTime, transform.position.y);
        }
        else this.gameObject.transform.position = new Vector2(transform.position.x + dir * Time.deltaTime, transform.position.y);


    }

    private bool isLeftWall()
    {
        return Physics2D.Raycast(coll.bounds.center, Vector2.left, 1f, ground);
        
    }
    private bool isRightWall()
    {
        return Physics2D.Raycast(coll.bounds.center, Vector2.right, 1f, ground);

    }

}
