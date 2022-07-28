using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGunPowerUp : PowerUp
{
    protected override void CollideWithPlayer(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var player = FindObjectOfType<Player>();
            player.ChangeGun();
            Destroy(gameObject);
        }
    }
}
