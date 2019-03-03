using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteChanger : MonoBehaviour
{
    public enum Block {Dirt, Grass}
    
    // Start is called before the first frame update
    public string season;
    public Block blockType;
    public int maxVariations;
    public Scene scene;
    Sprite blockSprite;

    public Texture2D[] spriteArray;
    SpriteRenderer spriteRenderer;

    public Texture2D temp2;

    
    public string path;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        season = scene.name.Split(' ')[0];
        spriteArray = new Texture2D[maxVariations];
        for(int i = 0; i < maxVariations; i++)
        {
            path = "Tiles/" + season + "/" + season + "_" + blockType.ToString() + (i + 1);
            var temp = Resources.Load(path);
            spriteArray[i] = Resources.Load(path) as Texture2D;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
