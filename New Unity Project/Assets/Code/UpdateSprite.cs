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

    private int randomSprite;
    void Start()
    {
        loader = GameObject.Find(blockType.ToString() + "Loader");
        spriteChanger = loader.GetComponent<SpriteChanger>();

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        randomSprite = Random.Range(0, spriteChanger.spriteArray.Length);
        Texture2D texture = spriteChanger.spriteArray[randomSprite];
        //texture.filterMode = FilterMode.Point;
        spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log(texture);

        if (blockType == Block.Grass)
        {
            if (spriteChanger.season == "Spring")
            {
                setOffset(-0.07f, 0.187f);
            }
            else if (spriteChanger.season == "Fall" || spriteChanger.season == "Summer")
            {
                //setOffset(-0.06f, 0.157f);
                setOffset(-0.06f, 0.1564f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setOffset(float colliderOffset, float positionOffset)
    {
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        if (randomSprite == 0)
        {
            boxCollider.offset = new Vector2(0f, -0.01f);
        }
        else
        {
            boxCollider.offset = new Vector2(0f, colliderOffset);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + positionOffset, this.transform.position.z);
        }
    }
}
