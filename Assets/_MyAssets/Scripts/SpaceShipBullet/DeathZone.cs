using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private const string SHIELD_TAG = "Shield";
    private const string WALL_TAG = "Wall";
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == SHIELD_TAG)
        {
            Destroy(other.gameObject);
            spriteRenderer.enabled = true;
        }
        var alien = other.GetComponent<Alien>();
        if (alien != null)
        {
            other.GetComponent<Alien>().Kill();
            spriteRenderer.enabled = true;
        }
        else if (other.tag != WALL_TAG) Destroy(other.gameObject);
    }
}
