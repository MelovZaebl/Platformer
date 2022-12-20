using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    
    public Text ScoreText;
    public static int ScoreInt;

    void Start()
    {
        ScoreInt = 0;
        ScoreText.text = "Score: " + ScoreInt;
    }
    void FixedUpdate()
    {
        
        ScoreText.text = "Score: " + ScoreInt;
    }


    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "Coin")
        {
            ScoreInt++;
            Destroy(Coin.gameObject);
            ScoreText.text = "Score: " + ScoreInt;
        }
    }
}
