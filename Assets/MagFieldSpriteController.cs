using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagFieldSpriteController : MonoBehaviour
{
    public Texture2D InTexture;
    public Texture2D OutTexture;
    public float FieldStrength;
    private Sprite inSprite;
    private Sprite outSprite;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
        
        outSprite = Sprite.Create(OutTexture, new Rect(0.0f, 0.0f, OutTexture.width, OutTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        inSprite = Sprite.Create(InTexture, new Rect(0.0f, 0.0f, InTexture.width, InTexture.height), new Vector2(0.5f, 0.5f), 100.0f);

        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = inSprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FieldStrength < 0)
        {
            sr.sprite = outSprite;
            
        }
        else
        {
            sr.sprite = inSprite;
        }
        this.transform.localScale = new Vector3(Math.Abs(FieldStrength) / 10, Math.Abs(FieldStrength) / 10, Math.Abs(FieldStrength) / 10);

    }
}
