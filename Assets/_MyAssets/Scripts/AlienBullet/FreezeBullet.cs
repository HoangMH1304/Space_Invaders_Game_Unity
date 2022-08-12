using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : Bullet
{
    // protected override void DealDamage(Collider2D other)
    // {
    //     var player = other.GetComponent<Player>();
    //     player.TurnIntoFreeze();
    //     var spaceshipEffect = other.GetComponent<SpaceShipEffect>();
    //     spaceshipEffect.TurnColor();
    // }

    protected override void HandleTriggerEnter(Collider2D other)
    {
        var target = other.GetComponent<ISpeed>();
        if (target != null)
        {
            target.ChangeSpeedEffect();
            target.SetSpeed(3);
            // float speed = target.GetSpeed();
            // speed /= 3;
            // target.SetSpeed(speed);
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


        // var bulletSpeed = other.GetComponent<Bullet>();
        // if (bulletSpeed != null && bulletSpeed.GetFreezeState() == false)  //error
        // {
        //     bulletSpeed.IsFreeze(true);
        //     float speed = bulletSpeed.GetSpeed();
        //     Debug.Log($"Original speed: {speed}");
        //     speed /= 3;
        //     bulletSpeed.SetSpeed(speed);
        //     Debug.Log(bulletSpeed.GetSpeed());
        // }
        // Destroy(gameObject);
    }
}