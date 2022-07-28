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
    protected float moveSpeed = 30;
    [SerializeField]
    protected int damage;
    protected AlienManager alienManager;
    protected Alien[] aliens;
    private Player player;
    private AnimationHandler animationHandler;

    protected void Start()
    {
        aliens = FindObjectsOfType<Alien>();
        GetReference();
        Move();
    }

    private void GetReference()
    {
        animationHandler = FindObjectOfType<AnimationHandler>();
        alienManager = FindObjectOfType<AlienManager>();
        player = FindObjectOfType<Player>();
    }

    virtual protected void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
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

    // protected void DealDamageAlien(Collider2D other)
    // {
    //     if (this.name == "FreezeBullet(Clone)")
    //     {
    //         var player = FindObjectOfType<Player>();
    //         StartCoroutine(DelayCoroutine(player));
    //     }
    //     var enemy = other.GetComponent<IHealth>();
    //     enemy.TakeDamage(damage);
    // }

    // IEnumerator DelayCoroutine(Player player)
    // {
    //     float speedBefore = player.GetMoveSpeed() / 2;
    //     player.SetMoveSpeed(speedBefore);
    //     Debug.Log($"Speed before: {speedBefore}");
    //     yield return new WaitForSeconds(5);
    //     float speedAfter = player.GetMoveSpeed() * 2;
    //     Debug.Log($"Speed after: {speedAfter}");
    //     player.SetMoveSpeed(speedAfter);
    // }
}