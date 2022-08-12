// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpaceShipBullet : Bullet
// {
//     [SerializeField]
//     protected int health;
//     [SerializeField]
//     private Sprite deathImage;
//     protected const float FREEZE_TIME = 2f;
//     protected const string NORMAL_ALIEN_BULLET = "AlienBullet(Clone)";
//     // protected bool isFreeze = false;
//     private float time = 0;
//     private SpriteRenderer spriteRenderer;
//     protected Alien[] aliens;

//     protected override void Start()
//     {
//         aliens = FindObjectsOfType<Alien>();
//         GetReference();
//         Move();
//     }

//     protected override void GetReference()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }
//     protected override void Move()
//     {
//         if (isFreeze == true && time < FREEZE_TIME)
//         {
//             moveSpeed = GetSpeed();
//             time += Time.deltaTime;
//             spriteRenderer.color = Color.cyan;
//         }
//         else
//         {
//             moveSpeed = GunManager.Instance.GetSpeed();
//             spriteRenderer.color = Color.white;
//         }
//         var rigidbody = GetComponent<Rigidbody2D>();
//         rigidbody.velocity = direction * moveSpeed;
//     }

//     protected override void HandleOtherTriggerEnter(Collider2D other)
//     {
//         if (other.name == NORMAL_ALIEN_BULLET)
//         {
//             health--;
//             if (health <= 0)
//             {
//                 Die();
//             }
//         }
//         if (other.tag == ALIEN_BULLET) return;
//         DestroyOtherThing(other);
//         // Destroy(gameObject);
//     }

//     protected virtual void DestroyOtherThing(Collider2D other)
//     {
//         Destroy(gameObject);
//     }

//     protected virtual void Die()
//     {
//         var image = GetComponent<SpriteRenderer>();
//         image.sprite = deathImage;
//         image.gameObject.transform.localScale = new Vector3(1, 1, 1);
//         Destroy(gameObject, 0.1f); //
//     }
// }