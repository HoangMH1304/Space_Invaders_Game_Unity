using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : PowerUp
{
    protected override void CollideWithPlayer(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var uIHandler = FindObjectOfType<UIHandler>();
            uIHandler.IncreaseHealth();
            Destroy(gameObject);
        }
    }
}
