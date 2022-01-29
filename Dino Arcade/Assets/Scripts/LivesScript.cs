using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
    //public static int scoreValue = 0;
    private static GameManager gameManager;
    Text lives;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        lives = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        lives.text = "Lives: " + gameManager.LivesGetter();
    }
}
