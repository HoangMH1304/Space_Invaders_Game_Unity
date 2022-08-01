using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEffect : Effect
{
    [SerializeField]
    private Sprite startingImage;
    [SerializeField]
    private Sprite altImage;
    [SerializeField]
    private Sprite giftImage;
    private Alien alien;

    protected override void Start()
    {
        GetReference();
        Init();
    }

    private void Init()
    {
        bool isSpecialAlien = alien.IsPowerUpAlien();
        if (isSpecialAlien == true) SpecialAlien();
        else NormalAlien();
    }

    private void GetReference()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alien = this.gameObject.GetComponent<Alien>();
    }

    private void SpecialAlien()
    {
        StartCoroutine(ChangeEffectAlienSprite());
    }

    private void NormalAlien()
    {
        StartCoroutine(ChangeAlienSprite());
    }

    IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
            }
            else if (spriteRenderer.sprite == altImage)
            {
                spriteRenderer.sprite = startingImage;
            }
            yield return new WaitForSeconds(countdownTime);
        }
    }

    IEnumerator ChangeEffectAlienSprite()
    {
        while (true)
        {
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = giftImage;
            }
            else if (spriteRenderer.sprite == giftImage)
            {
                spriteRenderer.sprite = startingImage;
            }
            yield return new WaitForSeconds(countdownTime);
        }
    }
}
