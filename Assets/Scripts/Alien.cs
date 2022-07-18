using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ship
{
    private const string PLAYER_TAG = "Player";
    private const string LEFTWALL_TAG = "LeftWall";
    private const string RIGHTWALL_TAG = "RightWall";
    public Sprite startingImage;

    public Sprite altImage;

    private SpriteRenderer spriteRenderer;

    public float secBeforeSpriteChange = 0.5f;

    [SerializeField]
    private float minFireRateTime = 3.0f;
    [SerializeField]
    private float maxFireRateTime = 5.0f;
    [SerializeField]
    private float baseFireWaitTime = 2.0f;
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
        if (other.gameObject.name == LEFTWALL_TAG)
        {
            TurnDirection(1);
            MoveDown();
        }
        if (other.gameObject.name == RIGHTWALL_TAG)
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
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == PLAYER_TAG)
        {
            var spaceShip = other.GetComponent<IHealth>();
            spaceShip.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    override public void TakeDamage(int damage)
    {
        GameManager.Instance.AddScore(10);
        Die();
    }
}
