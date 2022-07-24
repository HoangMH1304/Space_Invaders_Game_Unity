using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ship
{
    private const string PLAYER_TAG = "Player";
    private const string LEFTWALL_TAG = "LeftWall";
    private const string RIGHTWALL_TAG = "RightWall";
    public Sprite startingImage;
    public Sprite altImage;
    private SpriteRenderer spriteRenderer;
    private HandleAnimation handleAnimation;
    public float secBeforeSpriteChange = 0.5f;
    private int health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        handleAnimation = FindObjectOfType<HandleAnimation>();
        rb.velocity = Vector2.right * speed;
        health = GetAlienHealth();
        Debug.Log($"Health: {health}");
    }

    void TurnDirection(int direction)
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = speed * direction;
        rb.velocity = newVelocity;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 2;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == LEFTWALL_TAG)
        {
            TurnDirection(1);
            MoveDown();
        }
        if (other.gameObject.name == RIGHTWALL_TAG)
        {
            TurnDirection(-1);
            MoveDown();
        }
    }

    // public IEnumerator ChangeAlienSprite()
    // {
    //     while (true)
    //     {
    //         if (spriteRenderer.sprite == startingImage)
    //         {
    //             spriteRenderer.sprite = altImage;
    //         }
    //         else
    //         {
    //             spriteRenderer.sprite = startingImage;
    //             SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz2);
    //         }
    //         yield return new WaitForSeconds(secBeforeSpriteChange);
    //     }
    // }

    private bool GetChance()
    {
        return Random.Range(1, 100) <= 1;
    }

    private void FixedUpdate()
    {
        if (canShoot && GetChance())
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == PLAYER_TAG)
        {
            var spaceShip = other.GetComponent<IHealth>();
            spaceShip.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    override public void TakeDamage(int damage)
    {
        health--;
        if (health <= 0)
        {
            GameManager.Instance.AddScore(10);
            handleAnimation.OnDeadAnimation(this.gameObject);
            Die();
        }
    }
}
