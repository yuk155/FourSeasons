using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Block { Dirt, Grass };
    public Block blockType;

    SpriteChanger spriteChanger;
    public GameObject loader;

    SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    void Start()
    {
        loader = GameObject.Find(blockType.ToString() + "Loader");
        spriteChanger = loader.GetComponent<SpriteChanger>();

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        int randomSprite = Random.Range(0, spriteChanger.spriteArray.Length);
        Texture2D texture = spriteChanger.spriteArray[randomSprite];
        spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        if (blockType == Block.Grass)
        {
            boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
            if (randomSprite == 0)
            {
                boxCollider.offset.Set(0f, -0.01f);
            }
            else
            {
                boxCollider.offset.Set(0f, -0.06f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
