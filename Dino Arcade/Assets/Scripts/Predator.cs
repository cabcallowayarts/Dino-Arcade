using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PacmanEaten();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {

            Eat();

        }
    }

}
