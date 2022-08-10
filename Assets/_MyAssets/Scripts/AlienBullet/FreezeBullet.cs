using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : Bullet
{
    protected override void DealDamage(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        player.TurnIntoFreeze();
        var spaceshipEffect = other.GetComponent<SpaceShipEffect>();
        spaceshipEffect.TurnColor();
    }

    protected override void HandleBulletCollider(Collider2D other)
    {
        var bulletSpeed = other.GetComponent<Bullet>();
        if (bulletSpeed.GetFreezeState() == false)
        {
            bulletSpeed.IsFreeze(true);
            float speed = bulletSpeed.GetSpeed();
            Debug.Log($"Original speed: {speed}");
            speed /= 3;
            bulletSpeed.SetSpeed(speed);
            Debug.Log(bulletSpeed.GetSpeed());
        }
    }
}
