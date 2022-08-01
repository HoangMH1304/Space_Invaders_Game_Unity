using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ship
{
    private const string PLAYER_TAG = "Player";
    private const string LEFTWALL_TAG = "LeftWall";
    private const string RIGHTWALL_TAG = "RightWall";
    // [SerializeField]
    // private GameObject powerUp;
    bool isPowerUpAlien;
    private PowerUpContainer powerUp;
    private AlienEffect alienEffect;
    // Vector2 coordinateOfAlien;

    void Start()
    {
        GetReference();
        Init();
    }

    private void Init()
    {
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
        // else Destroy(gameObject);
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
            Die();
            // Destroy(gameObject);
        }
    }

    override public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            alienEffect.OnDead();
            GameManager.Instance.AddScore(10);
            if (isPowerUpAlien)
            {
                Instantiate(powerUp.RandomPowerUp().gameObject, this.transform.position, Quaternion.identity);
            }
            Die();
        }
    }

    public void Kill()
    {
        TakeDamage(health);
    }
}
