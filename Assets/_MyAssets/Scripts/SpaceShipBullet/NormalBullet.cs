using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    [SerializeField]
    private Sprite explosion;
    private SpriteRenderer spriteRenderer;

    protected override void DealDamage(Collider2D other)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = explosion;
        var enemy = other.GetComponent<IHealth>();
        enemy.TakeDamage(damage);
    }

    protected override void DestroyThis(Collider2D other)
    {
        if (other.tag != ALIEN_BULLET)
        {
            Destroy(gameObject, 0.05f);

        }
        if (other.name == "AlienBullet(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(gameObject, 0.05f);
        }
    }
}