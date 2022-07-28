using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    // [SerializeField]
    // private Ship gameobject;
    [SerializeField]
    private Sprite dead;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnColor()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        float time = 0;
        while (true)
        {
            if (spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.blue;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            if (time > 5) break;
            yield return new WaitForSeconds(0.5f);
            time += 0.5f;
        }
    }

    public void OnDead()
    {
        spriteRenderer.sprite = dead;
    }
}
