using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGunPowerUp : PowerUp
{
    protected override void CollideWithPlayer(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = FindObjectOfType<Player>();
            player.ChangeGun();
            Destroy(gameObject);
        }
    }
}
