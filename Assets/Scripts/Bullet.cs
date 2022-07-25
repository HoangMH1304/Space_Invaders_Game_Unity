using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string SHELD_TAG = "Shield";
    [SerializeField]
    private string enemyTag = "Player";
    [SerializeField]
    public Vector2 direction;
    [SerializeField]
    private float moveSpeed = 30;
    [SerializeField]
    private int damage;
    virtual protected void Start()
    {
        Move();
    }

    virtual protected void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    protected void HandleTriggerEnter(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            DealDamage(other);
        }
        if (other.tag == SHELD_TAG)
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    protected void DealDamage(Collider2D other)
    {
        // if (damage == -1)
        // {
        //     Alien[] aliens = FindObjectsOfType<Alien>();
        //     for (int i = aliens.Length - 1; i >= 0; i--)
        //     {
        //         if (aliens[i].name == other.name) aliens[i].Die();
        //     }
        // }
        // else
        // {
        //     var enemy = other.GetComponent<IHealth>();
        //     enemy.TakeDamage(damage);
        // }
        var enemy = other.GetComponent<IHealth>();
        if (damage == -1)
        {
            Alien[] aliens = FindObjectsOfType<Alien>();
            for (int i = aliens.Length - 1; i >= 0; i--)
            {
                if (aliens[i].name == other.name) aliens[i].TakeDamage(100);
            }
            enemy.TakeDamage(100);
        }
        else
        {
            enemy.TakeDamage(damage);
        }
    }
}