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
    private Player player;
    bool isMagnet = false;
    private void Start()
    {
        GetReference();
        if (player != null) isMagnet = player.GetMagnetItem();
        if (isMagnet == false) Move();
    }

    private void GetReference()
    {
        player = FindObjectOfType<Player>();
    }

    private void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
    }

    public void SetCondition(bool condition)
    {
        isMagnet = true;
    }

    private void Update()
    {
        if (isMagnet == false) return;
        transform.position = Vector2.MoveTowards(transform.position,
        player.transform.position, moveSpeed * Time.deltaTime);
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     HandleTriggerEnter(other);
    // }



    private void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollisionEnter2D(other);
    }

    private void HandleCollisionEnter2D(Collision2D other)
    {
        CollideWithPlayer(other);
        CollideWithWall(other);
    }

    protected virtual void CollideWithPlayer(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void CollideWithWall(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
    // private void HandleTriggerEnter(Collider2D other)
    // {
    //     CollideWithPlayer(other);
    //     CollideWithWall(other);
    // }

    // protected virtual void CollideWithPlayer(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    // private void CollideWithWall(Collider2D other)
    // {
    //     if (other.tag == "Wall")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
