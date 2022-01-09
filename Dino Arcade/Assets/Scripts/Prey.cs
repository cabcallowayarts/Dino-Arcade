using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour
{
    public int points = 50;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PreyEaten(this);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {

            Eat();

        }
    }

}
