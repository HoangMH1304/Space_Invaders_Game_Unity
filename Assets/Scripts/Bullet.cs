using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Sprite explodeAlien;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Wall") Destroy(gameObject);
        if(other.tag == "Alien")
        {
            SoundManager.instance.PlayOneShot(SoundManager.instance.alienDies);
            other.GetComponent<SpriteRenderer>().sprite = explodeAlien;
            Destroy(gameObject);        //destroy bullet
            DestroyObject(other.gameObject, 0.1f); //destroy explodeAlien after 0.5s
        }
        if(other.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
