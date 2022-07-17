using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string SHELD_TAG = "Shield";
    [SerializeField]
    private string enemyTag = "Player";
    [SerializeField]
    private float moveSpeed = 30;
    virtual protected void Start()
    {
        Move();
    }

    protected void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.down * moveSpeed;
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
        var enemy = other.GetComponent<IHealth>();
        enemy.TakeDamage(1);
    }
}
