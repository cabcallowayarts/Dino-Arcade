using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public Vector2 nextDirection { get; private set; }
    public Vector2 startingPosition { get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {

        Debug.Log("ResetStateMovement");
        this.speedMultiplier = 1.0f; 
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void Update()
    {
        // Try to move in the next direction while it's queued to make movements
        // more responsive
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(this.direction.ToString());
        Vector2 position = this.rigidbody.position;
        
        Vector2 translation = this.direction*this.speed * this.speedMultiplier * Time.fixedDeltaTime;

        this.rigidbody.MovePosition(position + translation);
        Debug.Log(position.ToString());
        Debug.Log(this.direction.ToString());
    }

    public void SetDirection(Vector2 direction)
    {
        // Only set the direction if the tile in that direction is available
        // otherwise we set it as the next direction so it'll automatically be
        // set when it does become available
        if (!Occupied(direction))
        {
            
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        // If no collider is hit then there is no obstacle in that direction
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * .75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }

}