using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private const string SHIELD_TAG = "Shield";
    private const string WALL_TAG = "Wall";
    private const string PLAYER_TAG = "Player";
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == PLAYER_TAG)
        {
            var enemy = other.GetComponent<IHealth>();
            enemy.TakeDamage(1);
            Handheld.Vibrate();
            return;
        }
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
        else if (other.tag != WALL_TAG && other.tag != PLAYER_TAG) Destroy(other.gameObject);
    }
}