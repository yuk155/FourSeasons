using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

}
