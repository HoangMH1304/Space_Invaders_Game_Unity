using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : PowerUp
{
    const int MAX_HEALTH = 3;

    protected override void CollideWithPlayer(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var uIHandler = FindObjectOfType<UIHandler>();
            var player = FindObjectOfType<Player>();
            int hearts = player.GetHealth();
            if (hearts < MAX_HEALTH)
            {
                hearts++;
                uIHandler.IncreaseHealth();
                player.SetHealth(hearts);
            }
            GameManager.Instance.UpdatePlayerHealth(hearts);

            Destroy(gameObject);
        }
    }
}
