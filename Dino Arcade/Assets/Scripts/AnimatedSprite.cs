using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;
    public float animationTime = .25f;
    public int animationFrame { get; private set; }
    public bool loop = true;
    public Sprite[] verticalSprites;
    public bool isHorizontal = true;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(WhichRepeat), this.animationTime, this.animationTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.AdvanceVertical();
            isHorizontal = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.AdvanceHorizontal();
            isHorizontal = true;
        }
        else
        {
            return;
        }
    }

    public void WhichRepeat()
    {
        if(isHorizontal)
        {
            AdvanceHorizontal();
        }
        else
        {
            AdvanceVertical();
        }
    }

    public void AdvanceHorizontal()
    {
        


            if (!this.spriteRenderer.enabled)
            {
                return;
            }

            this.animationFrame++;
            if (this.animationFrame >= this.sprites.Length && this.loop)
            {
                this.animationFrame = 0;
            }
            if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
            {
                this.spriteRenderer.sprite = this.sprites[this.animationFrame];
            }
        
    }

    public void AdvanceVertical()
    {
        
        

        
        if (!this.spriteRenderer.enabled)
        {
            return;
        }

        this.animationFrame++;
        if (this.animationFrame >= this.verticalSprites.Length && this.loop)
        {
            this.animationFrame = 0;
        }
        if (this.animationFrame >= 0 && this.animationFrame < this.verticalSprites.Length)
        {
            this.spriteRenderer.sprite = this.verticalSprites[this.animationFrame];
        }
        
    }

    public void Restart()
    {
        this.animationFrame = -1;
        AdvanceHorizontal();
    }

}
