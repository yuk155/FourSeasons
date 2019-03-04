using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParallaxCamera : MonoBehaviour
{
    [Tooltip("Array of background sprites")]
    public Transform[] backgrounds;
    [Tooltip("Proportion of camera-to-background movement")]
    private float[] parallaxScales;
    [Tooltip("Smoothness - needs to be greater than 0")]
    public float smoothing = 10f;

    public Transform player;
    private Vector3 previousCamPos;
   

    public string season;
    Scene scene;
    public string path;

    public Texture2D[] textureArray;

    public SpriteRenderer spriteRenderer;

    void Awake()
    {
<<<<<<< HEAD
        textureArray = new Texture2D[7];
=======
        textureArray = new Texture2D[6];
>>>>>>> backgrounds spawn
        scene = SceneManager.GetActiveScene();
        season = scene.name.Split(' ')[0];
        path = "Backgrounds/" + season + "/";

        /*hills in the top, sky on bottom*/

        var temp = Resources.Load(path + "Hills_Front");
        textureArray[0] = Resources.Load<Texture2D>(path + "Hills_Front");

        temp = Resources.Load(path + "Hills_Back");
        textureArray[1] = Resources.Load(path + "Hills_Back") as Texture2D;

        temp = Resources.Load(path + "Mountains_Front");
        textureArray[2] = Resources.Load(path + "Mountains_Front") as Texture2D;

        temp = Resources.Load(path + "Mountains_Middle");
        textureArray[3] = Resources.Load(path + "Mountains_Middle") as Texture2D;

        temp = Resources.Load(path + "Mountains_Back");
        textureArray[4] = Resources.Load(path + "Mountains_Back") as Texture2D;

        temp = Resources.Load(path + "Sky");
        textureArray[5] = Resources.Load(path + "Sky") as Texture2D;

<<<<<<< HEAD
        textureArray[6] = Resources.Load(path + "Sun") as Texture2D;
        GameObject sun = new GameObject();

        float zLocation = 10;
        float scale = 10;
        sun.name = "sun";
        sun.AddComponent<SpriteRenderer>();
        spriteRenderer = sun.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(textureArray[6], new Rect(0, 0, textureArray[6].width, textureArray[6].height), new Vector3(0, 0, -10));
        sun.transform.position = new Vector3(3.8f, -50.9f, 0f);
        sun.transform.localScale = new Vector3(sun.transform.localScale.x * scale, sun.transform.localScale.y * scale, sun.transform.localScale.z);
        sun.layer = 0;

        player = GameObject.Find("Teddy").gameObject.transform;
        //HARDCODED THINGS ARE BAD
        
        for (int i = 0; i < 6; i++)
        {
            GameObject empty = new GameObject();
            empty.name = "Parent";
            empty.AddComponent<SpriteRenderer>();
            spriteRenderer = empty.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite.Create(textureArray[i], new Rect(0, 0, textureArray[i].width, textureArray[i].height), new Vector3(0, 0, -10));
            empty.transform.position = new Vector3(-29f, -29.5f, zLocation + i);
            empty.transform.localScale = new Vector3(empty.transform.localScale.x * scale, empty.transform.localScale.y * scale, empty.transform.localScale.z);
            empty.layer = 0;

            backgrounds[i] = empty.transform;
        }
        
        for(int i = 0; i < 6; i++)
        {
            GameObject empty = new GameObject();
            empty.name = "Child";
            empty.AddComponent<SpriteRenderer>();
            spriteRenderer = empty.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite.Create(textureArray[i], new Rect(0, 0, textureArray[i].width, textureArray[i].height), new Vector3(0, 0, -10));
            empty.transform.localScale = new Vector3(empty.transform.localScale.x * scale, empty.transform.localScale.y * scale, empty.transform.localScale.z);
            empty.transform.position = new Vector3(-29f + spriteRenderer.bounds.size.x, -29.5f, zLocation + i);
            empty.layer = 0;
            empty.tag = "Child";
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

=======
        player = GameObject.Find("Teddy").gameObject.transform;
        //HARDCODED THINGS ARE BAD
        float zLocation = 10;
        float scale = 10;
        for (int i = 0; i < 6; i++)
        {
            GameObject empty = new GameObject();
            empty.AddComponent<SpriteRenderer>();
            spriteRenderer = empty.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite.Create(textureArray[i], new Rect(0, 0, textureArray[i].width, textureArray[i].height), new Vector3(0, 0, -10));

            empty.transform.position = new Vector3(empty.transform.position.x, empty.transform.position.y, zLocation + i);
            empty.transform.localScale = new Vector3(empty.transform.localScale.x * scale, empty.transform.localScale.y * scale, empty.transform.localScale.z);
            
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
>>>>>>> backgrounds spawn
        previousCamPos = player.position;

        parallaxScales = new float[backgrounds.Length];

<<<<<<< HEAD

=======
        
>>>>>>> backgrounds spawn
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
<<<<<<< HEAD
        int index = 0;
        foreach (GameObject child in GameObject.FindGameObjectsWithTag("Child"))
        {
            child.transform.parent = backgrounds[index];
            index++;
        }
=======
        
>>>>>>> backgrounds spawn
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - player.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x - parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = player.position;
    }
}
