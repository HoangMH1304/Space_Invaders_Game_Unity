using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour, IHealth
{

    public float speed = 10;

    private Rigidbody2D rb;

    public Sprite startingImage;

    public Sprite altImage;

    private SpriteRenderer spriteRenderer;

    public float secBeforeSpriteChange = 0.5f;

    public GameObject alienBullet;
    [SerializeField]
    private float minFireRateTime = 3.0f;
    [SerializeField]
    private float maxFireRateTime = 5.0f;
    [SerializeField]
    private float baseFireWaitTime = 2.0f;
    [SerializeField]
    private Sprite explodeAlien;
    public Sprite explodedShipImage;
    private float time;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeAlienSprite());
        time = 0;
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
        if (other.gameObject.name == "LeftWall")
        {
            TurnDirection(1);
            MoveDown();
        }
        if (other.gameObject.name == "RightWall")
        {
            TurnDirection(-1);
            MoveDown();
        }
    }

    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
            }
            else
            {
                spriteRenderer.sprite = startingImage;
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz2);
            }
            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= baseFireWaitTime)
        {
            time = 0;
            baseFireWaitTime = Random.Range(minFireRateTime, maxFireRateTime);
            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var spaceShip = other.GetComponent<IHealth>();
            spaceShip.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.AddScore(10);
        Die();
    }

    private void Die()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = explodeAlien;
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
        Destroy(gameObject, 0.1f);
    }

}
