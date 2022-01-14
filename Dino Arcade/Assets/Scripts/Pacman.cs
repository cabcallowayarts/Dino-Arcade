using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    public AnimatedSprite deathSequence;
    //public AnimatedSprite Dino;
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public Movement movement { get; private set; }

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collider = GetComponent<Collider2D>();
        this.movement = GetComponent<Movement>();
        //this.Dino = 
    }

    private void Update()
    {
        // Set the new direction based on the current input
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector2.up);
            //Dino.AdvanceVertical();
            this.spriteRenderer.flipY = false;
            

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
            //Dino.AdvanceVertical();
            this.spriteRenderer.flipY = true;
            

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
            //Dino.AdvanceHorizontal();
            this.spriteRenderer.flipY = false;
            this.spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
            //Dino.AdvanceHorizontal();
            this.spriteRenderer.flipY = false;
            this.spriteRenderer.flipX = true;
        }


        // Rotate pacman to face the movement direction
        //float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        //this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    

    public void ResetState()
    {
        this.enabled = true;
        //this.spriteRenderer.enabled = true;
        this.collider.enabled = true;
        //this.deathSequence.enabled = false;
        //.deathSequence.spriteRenderer.enabled = false;
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }
}
