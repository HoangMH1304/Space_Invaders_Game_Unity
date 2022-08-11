using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : Bullet
{
    [SerializeField]
    private GameObject deathZone;
    [SerializeField]
    private int health = 2;
    // int[] dx = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
    // int[] dy = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };

    // override protected void DealDamage(Collider2D other)
    // {
    //     Vector2 pos = other.gameObject.GetComponent<Ship>().GetCoordinate();
    //     for (int i = 0; i < 9; i++)
    //     {
    //         int dirX = (int)pos.x + dx[i];
    //         int dirY = (int)pos.y + dy[i];
    //         if (dirX >= 0 && dirX < 5 && dirY >= 0 && dirY < 5 && alienManager.GetAlienInMatrix(dirX, dirY) != null)
    //         {
    //             var alien = alienManager.GetAlienInMatrix(dirX, dirY);
    //             // alien.TakeDamage(alien.GetAlienHealth());
    //             alien.GetComponent<Alien>().Kill();
    //         }
    //     }
    // }

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