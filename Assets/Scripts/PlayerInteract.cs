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

    private void OnCollisionEnter2D(Collision2D otherColl)
    {
        Debug.Log($"{otherColl.gameObject.tag}");
        if(otherColl.gameObject.tag == "Enemy")
        {
            rb.AddForce(Vector2.up*10, ForceMode2D.Impulse);
        }
    }
}
