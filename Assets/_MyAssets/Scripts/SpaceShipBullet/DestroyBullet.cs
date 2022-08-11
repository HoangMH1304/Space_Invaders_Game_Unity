using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : Bullet
{
    private const string ALIEN_TAG = "AlienBullet(Clone)";
    [SerializeField]
    private int health = 2;
    [SerializeField]
    private Sprite dead;

    override protected void DealDamage(Collider2D other)
    {
        for (int i = aliens.Length - 1; i >= 0; i--)
        {
            if (aliens[i] == null) continue;
            if (aliens[i].name == other.name)
                aliens[i].Kill();
        }
    }

    protected override void HandleTriggerEnter(Collider2D other)
    {
        // if (GameObject.FindGameObjectWithTag("Aim") != null && other.gameObject != chooseAlien.gameObject)
        //     Destroy(targetIcon);
        if (other.tag == ENEMY_TAG)
        {
            DealDamage(other);
        }
        if (other.tag == SHIELD_TAG)
        {
            Destroy(other.gameObject);
        }
        if (other.name == "AlienBullet(Clone)")
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
        }
        if (other.tag == ALIEN_BULLET) return;
        Destroy(gameObject);
    }

    private void Die()
    {
        var image = GetComponent<SpriteRenderer>();
        image.sprite = dead;
        image.gameObject.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject, 0.1f); //
    }
}
