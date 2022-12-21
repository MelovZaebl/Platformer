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

        ScoreInt = PlayerPrefs.GetInt("Score");
        ScoreText.text = "Score: " + ScoreInt;
        if (LivesScript.current < 0)
        {
            ScoreInt -= 10;
        }
    }
    void FixedUpdate()
    {
        
        PlayerPrefs.SetInt("Score", ScoreInt);
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
