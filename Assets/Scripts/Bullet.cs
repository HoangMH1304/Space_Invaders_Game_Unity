using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("OnTriggerEnter + " + other.name);
        if(other.tag == "Wall") Destroy(gameObject);
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log("OnCollisionEnter + " + other.gameObject.name);
    //     if(other.gameObject.tag == "Wall") Destroy(gameObject);
    // }

}
