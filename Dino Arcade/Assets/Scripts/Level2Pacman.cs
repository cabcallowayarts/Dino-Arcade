using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Pacman : Pacman
{
    protected override void Update()
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
            this.spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
            //Dino.AdvanceHorizontal();
            this.spriteRenderer.flipY = false;
            this.spriteRenderer.flipX = false;
        }


        // Rotate pacman to face the movement direction
        //float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        //this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
}
