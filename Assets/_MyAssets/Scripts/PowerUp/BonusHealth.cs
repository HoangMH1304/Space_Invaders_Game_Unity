using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : PowerUp
{
    protected override void CollideWithPlayer(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var uIHandler = FindObjectOfType<UIHandler>();
            uIHandler.IncreaseHealth();
            Destroy(gameObject);
        }
    }
}
