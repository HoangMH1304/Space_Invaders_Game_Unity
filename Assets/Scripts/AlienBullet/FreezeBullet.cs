using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : Bullet
{
    protected override void DealDamage(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        player.TurnIntoFreeze();
    }
}
