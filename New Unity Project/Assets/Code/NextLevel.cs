using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public float maxTime;
    public string GameMessage = "";
    public string nextLevel;

    float timer; 

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        if(GameMessage == "")
        {
            GameMessage = "Next Level";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Teddy")
        {
            playerController = collider.gameObject.GetComponent<PlayerController>();
            playerController.canMove = false;
            //ADD IN CODE TO DISPLAY THE NEXT MESSAGE USING CANVAS OBJECT
        }
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            SceneManager.LoadScene(nextLevel);
        }


        
    }
}
