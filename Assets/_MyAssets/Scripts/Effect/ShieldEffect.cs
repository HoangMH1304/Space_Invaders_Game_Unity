using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : Effect
{
    public override void OnDead()
    {
        spriteRenderer.sprite = deadImage;
        spriteRenderer.color = Color.white;
        transform.localScale -= new Vector3(1, 1, 0);
    }
}
