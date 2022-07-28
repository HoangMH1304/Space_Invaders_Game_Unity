using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField]
    private GameObject shield;

    protected override void CollideWithPlayer(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject player = GameObject.Find("SpaceShip");
            Instantiate(shield, player.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
