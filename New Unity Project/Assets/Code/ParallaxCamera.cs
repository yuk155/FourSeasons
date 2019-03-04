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
        textureArray = new Texture2D[6];
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
            empty.layer = -1;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        previousCamPos = player.position;

        parallaxScales = new float[backgrounds.Length];

        
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
        
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
