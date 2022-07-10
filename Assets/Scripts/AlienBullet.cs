using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public float moveSpeed = 30;
    public Sprite explodeShip;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Wall") Destroy(gameObject);
        if(other.tag == "Player")
        {
            SoundManager.instance.PlayOneShot(SoundManager.instance.shipExplosion);
            other.GetComponent<SpriteRenderer>().sprite = explodeShip;
            Destroy(gameObject);
            DestroyObject(other.gameObject, 0.1f);
        }
        if(other.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
