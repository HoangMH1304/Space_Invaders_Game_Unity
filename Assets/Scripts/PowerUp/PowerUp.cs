using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 30f;
    [SerializeField]
    private Vector2 direction;
    private void Start()
    {
        Move();
    }

    private void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    private void HandleTriggerEnter(Collider2D other)
    {
        CollideWithPlayer(other);
        CollideWithWall(other);
    }

    protected virtual void CollideWithPlayer(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // var player = FindObjectOfType<Player>();
            // player.ChangeGun();
            Destroy(gameObject);
        }
    }
    private void CollideWithWall(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
