using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRandomSprite : MonoBehaviour
{
    public Sprite[] sprites;

    public float loopTime = 1f / 4f;

    SpriteRenderer spriteRenderer;

    float elapsedTime = 0f;

    public int currentIndex = 0;
    public int newIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Length > 1)
            currentIndex = Random.Range(0, sprites.Length);
        else
            currentIndex = 0;
        
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > loopTime)
        {
            elapsedTime = 0;

            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (sprites.Length > 1)
        {
            newIndex = 0;
            do
            {
                newIndex = Random.Range(0, sprites.Length);
            } while (newIndex == currentIndex);
            currentIndex = newIndex;

            spriteRenderer.sprite = sprites[currentIndex];
        }
        if (sprites.Length > 0)
            spriteRenderer.sprite = sprites[currentIndex];
    }
    
}
