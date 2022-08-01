using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string SHIELD_TAG = "Shield";
    private const string POWER_UP = "PowerUp";
    [SerializeField]
    private string enemyTag = "Player";
    [SerializeField]
    public Vector2 direction;
    [SerializeField]
    protected float moveSpeed = 30f;
    [SerializeField]
    protected int damage;
    protected AlienManager alienManager;
    protected Alien[] aliens;
    private Player player;
    private bool boosting = false;
    private float boostTimer = 0f;

    protected void Start()
    {
        aliens = FindObjectsOfType<Alien>();
        GetReference();
        Move();
    }

    private void GetReference()
    {
        alienManager = FindObjectOfType<AlienManager>();
        player = FindObjectOfType<Player>();
    }

    public void NewSpeed()
    {
        moveSpeed *= 4f;
        Debug.Log($"Speed after: {moveSpeed}");
    }

    virtual protected void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer > 10f)
            {
                moveSpeed =
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    protected void HandleTriggerEnter(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            DealDamage(other);
        }
        if (other.tag == SHIELD_TAG)
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "EnergyShield" && this.tag == "AlienBullet")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    protected virtual void DealDamage(Collider2D other)
    {
        var enemy = other.GetComponent<IHealth>();
        enemy.TakeDamage(damage);
    }
}