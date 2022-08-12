// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AlienBullet : Bullet
// {
//     protected override void HandleOtherTriggerEnter(Collider2D other)
//     {
//         if (other.tag == ENERGY_SHIELD)
//         {
//             Destroy(other.gameObject);
//         }
//         HandleBulletCollider(other);
//         Destroy(gameObject);
//     }

//     protected virtual void HandleBulletCollider(Collider2D other)
//     {

//     }
// }
