using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : Bullet
{
    [SerializeField]
    private GameObject deathZone;
    [SerializeField]
    private int health = 2;

    protected override void TimeUp()
    {
        DealDamage();
    }
    protected override void HandleTriggerEnter(Collider2D other)
    {
        if (other.tag == "Wall") Destroy(gameObject);
        if (other.tag == ENEMY_TAG || other.tag == SHIELD_TAG)
        {
            DealDamage();
            return;
        }
        if (other.name == "AlienBullet(Clone)")
        {
            health--;
            Debug.Log($"health: {health}");
            if (health <= 0)
            {
                DealDamage();
                return;
            }
        }
        // if (other.tag != ENERGY_SHIELD && other.tag != ALIEN_BULLET) Destroy(gameObject);
        // Destroy(gameObject);
    }

    private void DealDamage()
    {
        // if ()
        GameObject dz = Instantiate(deathZone, transform.position, Quaternion.identity);
        Destroy(dz, 0.15f);
        Destroy(gameObject);
    }
}