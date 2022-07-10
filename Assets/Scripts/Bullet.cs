using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public Sprite explodeAlien;
    private Rigidbody2D rb;
    private UpdateScore updateScore;

    void Start()
    {
        updateScore = GameObject.Find("Score").GetComponent<UpdateScore>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Wall") 
        {
            Destroy(gameObject);
        }
        if(other.tag == "Alien")
        {
            SoundManager.instance.PlayOneShot(SoundManager.instance.alienDies);
            other.GetComponent<SpriteRenderer>().sprite = explodeAlien;
            Destroy(gameObject);        //destroy bullet
            DestroyObject(other.gameObject, 0.1f); //destroy explodeAlien after 0.1s
            updateScore.IncreseScore();
        }
        if(other.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
