using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpeed
{
    protected const string SHIELD_TAG = "Shield";
    protected const string POWER_UP = "PowerUp";
    protected const string ENERGY_SHIELD = "EnergyShield";
    protected const string ALIEN_BULLET = "AlienBullet";
    protected const string SPACESHIP_BULLET = "Bullet";
    protected const float FREEZE_TIME = 2f;
    [SerializeField]
    protected string ENEMY_TAG = "Player";
    protected string ENEMY_BULLET_TAG;
    [SerializeField]
    public Vector2 direction;
    [SerializeField]
    protected float moveSpeed = 30f;
    protected float originalSpeed;
    [SerializeField]
    protected int damage;
    protected Alien[] aliens;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    bool isFreeze = false;

    protected void Start()
    {
        aliens = FindObjectsOfType<Alien>();
        GetReference();
        originalSpeed = moveSpeed;
        // Move();
        ENEMY_BULLET_TAG = (this.tag == SPACESHIP_BULLET) ? SPACESHIP_BULLET : ALIEN_BULLET;
    }

    private void GetReference()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        // if (this.tag == "Bullet")            //need fix
        // {
        //     if (isFreeze == true) moveSpeed = GetSpeed();
        //     else moveSpeed = GunManager.Instance.GetSpeed();
        // }
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public void GetOldSpeed()
    {
        moveSpeed = originalSpeed;
    }

    public void SetSpeed(float x)
    {
        moveSpeed /= x;
        Invoke("GetOldSpeed", 2.5f);
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

    public void ChangeSpeedEffect()
    {
        TurnColor();
    }

    public void TurnColor()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        float time = 0;
        while (true)
        {
            if (spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.cyan;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            if (time > FREEZE_TIME) break;
            yield return new WaitForSeconds(0.5f);
            time += 0.5f;
            Debug.Log($"Time: {time}");
        }
    }
}