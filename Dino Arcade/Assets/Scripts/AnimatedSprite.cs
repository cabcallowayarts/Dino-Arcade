﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public AnimatedSprite[] sprites;
    public float animationTime = .25f;
    public int animationFrame { get; private set; }
    public bool loop = true;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
