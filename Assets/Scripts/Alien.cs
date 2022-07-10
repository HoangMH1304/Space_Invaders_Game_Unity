using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    
	public float speed = 10;
 
	private Rigidbody2D rb;
 
	public Sprite startingImage;
 
	public Sprite altImage;
 
	private SpriteRenderer spriteRenderer;
 
	public float secBeforeSpriteChange = 0.5f;
 
	public GameObject alienBullet;
 
	public float minFireRateTime = 1.0f;
 
	public float maxFireRateTime = 3.0f;
 
	public float baseFireWaitTime = 3.0f;
 
	public Sprite explodedShipImage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeAlienSprite());
        baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);
    }

    void TurnDirection(int direction)
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = speed * direction;
        rb.velocity = newVelocity;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name == "LeftWall")
        {
            TurnDirection(1);
            MoveDown();
        }
        if(other.gameObject.name == "RightWall")
        {
            TurnDirection(-1);
            MoveDown();
        }
    }

    public IEnumerator ChangeAlienSprite()
    {
        while(true)
        {
            if(spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
				// SoundManager.instance.PlayOneShot(SoundManager.instance.alienBuzz1); 
            }else
            {
                spriteRenderer.sprite = startingImage;
                SoundManager.instance.PlayOneShot(SoundManager.instance.alienBuzz2);    
            }
            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }

    private void FixedUpdate() {
        if(Time.time > baseFireWaitTime)
        {
            baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);
            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            SoundManager.instance.PlayOneShot(SoundManager.instance.shipExplosion);
            other.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            Destroy(gameObject);
            DestroyObject(other.gameObject, 0.25f);
        }
    }
}
