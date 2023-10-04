using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> rSprites, lSprites, lastSprites;
    public float walkSpeed, frameRate;
    float x, y, idleTime;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        body.velocity = direction * walkSpeed;
        List<Sprite> sprites = GetSpritesUsingDirection();

        if (sprites != null)
        {
            float playtime = Time.time - idleTime;
            int totalFrames = (int)(playtime * frameRate);
            int frame = totalFrames % sprites.Count;
            spriteRenderer.sprite = sprites[frame];
            lastSprites = sprites;
        }
        else
        {
            idleTime = Time.time;
            spriteRenderer.sprite = lastSprites[0];
        }
    }

    List<Sprite> GetSpritesUsingDirection()
    {
        List<Sprite> selectedSprites = null;

        if (direction.x > 0)
        {
            selectedSprites = rSprites;
        }
        else if (direction.x < 0)
        {
            selectedSprites = lSprites;
        }
        else if (direction.y != 0)
        {
            if (lastSprites != null)
            {
                selectedSprites = lastSprites;

            }
        }


        return selectedSprites;
    }
}
