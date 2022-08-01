using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : Bullet
{
    override protected void DealDamage(Collider2D other)
    {
        for (int i = aliens.Length - 1; i >= 0; i--)
        {
            if (aliens[i] == null) continue;
            if (aliens[i].name == other.name)
                aliens[i].Kill();
        }
    }
}
