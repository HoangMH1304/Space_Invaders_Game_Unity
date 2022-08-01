using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField]
    protected float countdownTime;
    [SerializeField]
    protected Sprite deadImage;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnDead()
    {
        spriteRenderer.sprite = deadImage;
    }
}
