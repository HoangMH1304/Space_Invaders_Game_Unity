using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : Bullet
{
    protected override void HandleTriggerEnter(Collider2D other)
    {
        var target = other.GetComponent<ISpeed>();
        if (target != null)
        {
            target.ChangeSpeedEffect();
            target.SetSpeed(3);
        }
        else
        {
            if (other.tag == SHIELD_TAG)
            {
                other.GetComponent<ShieldEffect>().OnDead();
                Destroy(other.gameObject, 0.1f);
            }
            if (other.tag == ENERGY_SHIELD)
            {
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject);
    }
}