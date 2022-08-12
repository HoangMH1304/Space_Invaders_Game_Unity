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
    [SerializeField]
    protected Sprite deathImage;
    protected Alien[] aliens;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    bool isFreeze = false;
    float time = 0;
    protected float timeToExplode = 3.5f;

    protected void Start()
    {
        aliens = FindObjectsOfType<Alien>();
        GetReference();
        originalSpeed = moveSpeed;
        ENEMY_BULLET_TAG = (this.tag == SPACESHIP_BULLET) ? SPACESHIP_BULLET : ALIEN_BULLET;
    }

    private void GetReference()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeToExplode -= Time.deltaTime;
        if (timeToExplode <= 0 && deathImage != null)
        {
            TimeUp();
            return;
            // spriteRenderer.sprite = deathImage;
            // gameObject.transform.localScale = new Vector3(1, 1, 1);
            // Destroy(gameObject, 0.05f);
            // return;
        }
        Move();
    }

    protected virtual void TimeUp()
    {
        spriteRenderer.sprite = deathImage;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject, 0.05f);
    }
    virtual protected void Move()
    {
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
            DestroyThis(other);
        }
    }

    protected virtual void DestroyThis(Collider2D other)
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
        DestroyThis(other);
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
            if (spriteRenderer == null) yield break;
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