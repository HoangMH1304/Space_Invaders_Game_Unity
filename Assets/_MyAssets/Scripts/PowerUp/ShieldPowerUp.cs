using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField]
    private GameObject shield;

    protected override void CollideWithPlayer(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("SpaceShip");
            Instantiate(shield, player.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
