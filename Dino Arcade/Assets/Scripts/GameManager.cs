using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Prey[] prey;
    public Pacman pacman;
    public Transform pellets;
    public int score { get; private set; }
    public int lives { get; private set; }

    public Text gameOverText;
    

    public int ScoreGetter()
    {
        int value = score;
        return value;
    }

    public int LivesGetter()
    {
        int value = lives;
        return value;
    }
    
    
    private void Start()
    {
        this.pacman = GameObject.Find("Pacman").GetComponent<Pacman>();
        NewGame();
    }

    private void Update()
    {
        if (this.lives<=0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        //Enable this when game is ready to be exported
        //SceneManager.LoadScene("TitleScreen");
        SetScore(0);
        SetLives(3);
        NewRound();

    }

    private void NewRound()
    {
        this.gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        this.gameOverText.enabled = false;

        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }
        ResetState();
        
    }

    private void ResetState()
    {
        for (int i = 0; i < this.prey.Length; i++)
        {
            this.prey[i].gameObject.SetActive(true);
        }
        
        this.pacman.ResetState();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        
    }

    private void GameOver()
    {
        this.gameOverText.enabled = true;

        for (int i = 0; i < this.prey.Length; i++)
        {
            this.prey[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
        
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

 

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);

    }

    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);


        SetLives(this.lives - 1);
        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
            
        }
        else
        {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        
        pellet.gameObject.SetActive(false);

        /*if (!(pellet.gameObject.activeSelf))
        {
            Debug.Log("this works");
        }*/
        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        
        pellet.gameObject.SetActive(false);
        
        SetScore(this.score + pellet.PowerPelletPoints);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if(pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void PreyEaten(Prey prey)
    {
        prey.gameObject.SetActive(false);
        prey.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (!(prey.gameObject.activeSelf))
        {
            Debug.Log("prey works");
        }
        SetScore(this.score + prey.points);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

   

    
}
