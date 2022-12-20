using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>(); 
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void OnTriggerEnter2D(Collider2D otherColl)
    {
        Debug.Log($"{otherColl.gameObject.tag}");
        GameObject coll = otherColl.gameObject;

        if (coll.gameObject.tag == "EnemyHead")
        {
            rb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
        }


    }
    // Update is called once per frame
    void Update()
    {
        OutBounced();
       
    }

    private void OutBounced()
    {
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(0);
        }
    }

    
}
