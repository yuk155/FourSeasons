using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public float snowMoveSpeed = 3;
    public float iceSlideSpeed = 7;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Vector2 move;

    //private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
       // spriteRenderer = GetComponent<SpriteRenderer>();
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
        /*
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        */
        targetVelocity = move * maxSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            maxSpeed = 3;
        }
        if (collision.gameObject.tag == "Ice")
        {
            float iceMove = move.x;
            rb2d.AddForce(new Vector2(iceMove * iceSlideSpeed, rb2d.velocity.y));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            float iceMove = move.x;
            rb2d.AddForce(new Vector2(iceMove * iceSlideSpeed, rb2d.velocity.y));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Snow")
        {  
            maxSpeed = 7;
        }
        if (collision.gameObject.tag == "Ice")
        {
            Debug.Log("Leaving Ice");
            rb2d.angularVelocity = 0f;
            rb2d.velocity = Vector2.zero;
        }
    }

    /*
    public float speed = 5;

    public Vector2 newPos;
    public Vector2 currPos;
    public Vector2 myPos;
    public float fraction;
    public float journeyLength;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (fraction < 1)
        {
            fraction = ((Time.time - startTime) * speed) / journeyLength;
            this.transform.position = Vector2.Lerp(currPos, newPos, fraction);

        }
    }



    void MoveLeft()
    {
        currPos = this.transform.position;
        newPos = new Vector2(this.transform.position.x - speed, this.transform.position.y);
        journeyLength = Vector2.Distance(currPos, newPos);
        startTime = Time.time;
        fraction = 0;
    }

    void MoveRight()
    {
        currPos = transform.position;
        newPos = new Vector2(this.transform.position.x + speed, this.transform.position.y);
        journeyLength = Vector2.Distance(currPos, newPos);
        startTime = Time.time;
        fraction = 0;
    }

    */

}
