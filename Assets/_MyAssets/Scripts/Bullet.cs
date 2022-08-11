using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected const string SHIELD_TAG = "Shield";
    protected const string POWER_UP = "PowerUp";
    protected const string ENERGY_SHIELD = "EnergyShield";
    protected const string ALIEN_BULLET = "AlienBullet";
    protected const string SPACESHIP_BULLET = "Bullet";
    [SerializeField]
    protected string ENEMY_TAG = "Player";
    protected string ENEMY_BULLET_TAG;
    [SerializeField]
    public Vector2 direction;
    [SerializeField]
    protected float moveSpeed = 30f;
    [SerializeField]
    protected int damage;
    protected AlienManager alienManager;
    protected Alien[] aliens;
    private Player player;
    private Effect effect;
    private ItemManager itemManager;
    bool isFreeze = false;

    protected void Start()
    {
        // if (this.tag == "Bullet") Debug.Log($"Speed: {moveSpeed}");
        aliens = FindObjectsOfType<Alien>();
        GetReference();
        // Move();
        ENEMY_BULLET_TAG = (this.tag == SPACESHIP_BULLET) ? SPACESHIP_BULLET : ALIEN_BULLET;
    }

    private void GetReference()
    {
        alienManager = FindObjectOfType<AlienManager>();
        itemManager = FindObjectOfType<ItemManager>();
        player = FindObjectOfType<Player>();
        effect = FindObjectOfType<Effect>();
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public void SetSpeed(float x)
    {
        moveSpeed = x;
    }

    private void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        if (this.tag == "Bullet")
        {
            if (isFreeze == true) moveSpeed = GetSpeed();
            else moveSpeed = GunManager.Instance.GetSpeed();
        }
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
    }

    public void IsFreeze(bool logic)
    {
        isFreeze = logic;
    }

    public bool GetFreezeState()
    {
        return isFreeze;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    protected virtual void HandleTriggerEnter(Collider2D other)
    {
        if (other.tag == SPACESHIP_BULLET)
        {
            HandleBulletCollider(other);
        }
        else
        {
            if (other.tag == ENEMY_TAG)
            {
                DealDamage(other);
            }
            if (other.tag == SHIELD_TAG)
            {
                other.GetComponent<ShieldEffect>().OnDead();
                Destroy(other.gameObject, 0.1f);
            }
            if (other.tag == ENERGY_SHIELD && this.tag == ALIEN_BULLET)
            {
                Destroy(other.gameObject);
            }
            if (other.tag == ENEMY_BULLET_TAG) return;
            Destroy();
        }
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    protected virtual void DealDamage(Collider2D other)
    {
        var enemy = other.GetComponent<IHealth>();
        enemy.TakeDamage(damage);
    }

    protected virtual void HandleBulletCollider(Collider2D other)
    {
        Destroy();
        // Destroy(other.gameObject);
    }
}