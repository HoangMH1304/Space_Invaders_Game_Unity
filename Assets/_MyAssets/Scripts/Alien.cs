using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ship
{
    private const string PLAYER_TAG = "Player";
    private const string LEFTWALL_TAG = "LeftWall";
    private const string RIGHTWALL_TAG = "RightWall";
    private const string SHIELD_TAG = "Shield";
    bool isPowerUpAlien;
    private PowerUpContainer powerUp;
    private AlienEffect alienEffect;
    // Vector2 coordinateOfAlien;

    void Start()
    {
        GetReference();
        Init();
    }

    private void FixedUpdate()
    {
        if (canShoot && GetChance())
        {
            Shoot();
        }
    }

    private void Init()
    {
        speed = TestManager.Instance.GetAlienSpeed();
        rigidBody.velocity = Vector2.right * speed;
        health = GetHealth();
        isPowerUpAlien = SpecialRate();
        if (isPowerUpAlien == true)
        {
            powerUp = FindObjectOfType<PowerUpContainer>();
            //just test
            // coordinateOfAlien = GetCoordinate();
            // Debug.Log($"Health: {health}, x: {coordinateOfAlien.y}, y: {coordinateOfAlien.x}");
            // Debug.Log(coordinateOfAlien);
        }
    }

    public void DestroyNormalAlien()
    {
        if (isPowerUpAlien == false) Die();
    }

    private void GetReference()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        alienEffect = GetComponent<AlienEffect>();
    }

    private bool SpecialRate()
    {
        return Random.Range(1, 100) <= 20;
    }

    public bool IsPowerUpAlien()
    {
        return isPowerUpAlien;
    }

    void TurnDirection(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 2;
        transform.position = position;
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.name == LEFTWALL_TAG)
    //     {
    //         TurnDirection(1);
    //         MoveDown();
    //     }
    //     if (other.gameObject.name == RIGHTWALL_TAG)
    //     {
    //         TurnDirection(-1);
    //         MoveDown();
    //     }
    //     if (other.gameObject.tag == PLAYER_TAG)
    //     {
    //         var spaceShip = other.gameObject.GetComponent<IHealth>();
    //         spaceShip.TakeDamage(1);
    //     }
    //     // if (other.gameObject.tag == SHIELD_TAG)
    //     // {
    //     //     other.gameObject.GetComponent<ShieldEffect>().OnDead();
    //     //     Destroy(other.gameObject, 0.1f);
    //     //     // Destroy(other.gameObject);
    //     //     Debug.Log(dirX);
    //     //     TurnDirection(dirX);
    //     // }
    // }

    private void OnTriggerEnter2D(Collider2D other)
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
        if (other.gameObject.tag == PLAYER_TAG)
        {
            var spaceShip = other.gameObject.GetComponent<IHealth>();
            //add effect
            spaceShip.TakeDamage(1);
            Handheld.Vibrate();
        }
        if (other.gameObject.tag == SHIELD_TAG)
        {
            other.gameObject.GetComponent<ShieldEffect>().OnDead();
            Destroy(other.gameObject, 0.1f);
        }
    }

    private bool GetChance()
    {
        int rate = TestManager.Instance.GetAlienShootRate();
        return Random.Range(1, rate * 100) <= 1;
    }

    // private bool GetChanceTest(int rate)
    // {
    //     rate = TestManager.Instance.GetAlienShootRate();
    //     return Random.Range(1, rate * 100) <= 1;
    // }

    override public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            alienEffect.OnDead();
            GameManager.Instance.AddScore(10);
            if (isPowerUpAlien)
            {
                Instantiate(powerUp.RandomPowerUp().gameObject,
                this.transform.position, Quaternion.identity);
            }
            Die();
        }
    }

    public void Kill()
    {
        TakeDamage(health);
    }
}