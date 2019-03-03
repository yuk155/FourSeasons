﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    private SpriteRenderer spriteRenderer;
    public float waterMoveSpeed = 4;
    public float snowMoveSpeed = 3;
    public float iceSlideSpeed = 7;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Vector2 move;

    private float speed;


    public bool flipSprite;

    private WaterBlock waterBlock;
    enum Direction { North, East, South, West, None }

    //public bool shouldFlip = false;

    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        speed = maxSpeed;
        // animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        if (move.x > 0f)
        {
            flipSprite = false;
        }
        else if (move.x < 0f)
        {
            flipSprite = true;
        }
        spriteRenderer.flipX = flipSprite;
        /*
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        */
        targetVelocity = move * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            speed = snowMoveSpeed;
            rb2d.angularVelocity = 0f;
            rb2d.velocity = Vector2.zero;
        }
        if (collision.gameObject.tag == "Ice")
        {
            float iceMove = move.x;
            rb2d.AddForce(new Vector2(iceMove * iceSlideSpeed * 2, rb2d.velocity.y));
        }
        else
        {
            //Reset Ice slide to 0
            stopVelocity();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            float iceMove = move.x;
            rb2d.AddForce(new Vector2(iceMove * iceSlideSpeed * 2, rb2d.velocity.y));
        }
        if (collision.gameObject.tag == "Snow")
        {
            speed = snowMoveSpeed;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            speed = maxSpeed;
        }
        if (collision.gameObject.tag == "Ice")
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            waterBlock = collider.gameObject.GetComponent<WaterBlock>();
            waterPush(waterBlock);
        }
        if (collider.gameObject.tag == "Water Edge")
        {
            stopVelocity();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            Debug.Log("Enter Water");
            rb2d.angularVelocity = 0f;
            //rb2d.velocity = Vector2.zero;
            //gravityModifier = 1f;
            // waterBlock = collider.gameObject.GetComponent<WaterBlock>();
            waterPush(waterBlock);
        }
        if(collider.gameObject.tag == "Water Edge")
        {
            Debug.Log("Enter Water Edge");

            stopVelocity();
        }
    }

    private void stopVelocity()
    {
        rb2d.angularVelocity = 0f;
        rb2d.velocity = Vector2.zero;
        gravityModifier = 1f;
    }

    private void waterPush(WaterBlock waterBlock)
    {
        
        Vector2 waterDirection = directionToVector(waterBlock.direction);
        gravityModifier = -0.05f;
        rb2d.AddForce(new Vector2(waterMoveSpeed * waterDirection.x, waterMoveSpeed * waterDirection.y));
    }

    

    private Vector2 directionToVector(WaterBlock.Direction direction)
    {
        switch (direction)
        {
            case WaterBlock.Direction.Up:
                return Vector2.up;
            case WaterBlock.Direction.Down:
                return Vector2.down;
            case WaterBlock.Direction.Right:
                return Vector2.right;
            case WaterBlock.Direction.Left:
                return Vector2.left;
            case WaterBlock.Direction.None:
                return Vector2.zero;
        }
        return Vector2.zero;

    }
}
