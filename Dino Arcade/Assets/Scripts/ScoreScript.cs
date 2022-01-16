using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //public static int scoreValue = 0;
    private static GameManager gameManager;
    Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        score.text = "Score: " + gameManager.ScoreGetter();
    }
}
