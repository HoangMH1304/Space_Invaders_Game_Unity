using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string SHELD_TAG = "Shield";
    [SerializeField]
    private string enemyTag = "Player";
    [SerializeField]
    public Vector2 direction;
    [SerializeField]
    private float moveSpeed = 30;
    [SerializeField]
    private int damage;
    private AlienManager alienManager;
    private Alien[] aliens;
    private List<Ship> ship;
    private Alien chooseAlien = null;
    private AnimationHandler animationHandler;
    // Type of Bullets:
    // 1: TargetBullet(Clone)
    // 2: BombBullet(Clone)
    // 3: DestroyBullet(Clone)
    int typeBullet;
    int[] dx = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
    int[] dy = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
    int minn = 10;
    virtual protected void Start()
    {
        if (gameObject.tag.Equals("Alien")) Debug.Log(this.gameObject.name);  //test
        aliens = FindObjectsOfType<Alien>();
        if (this.gameObject.name.Equals("TargetBullet(Clone)"))
        {
            typeBullet = 1;
        }
        else if (this.gameObject.name.Equals("BombBullet(Clone)"))
        {
            typeBullet = 2;
        }
        else if (this.gameObject.name.Equals("DestroyBullet(Clone)"))
        {
            typeBullet = 3;
        }
        else
        {
            //not special bullet
            typeBullet = 0;
        }
        GetReference();
        ship = alienManager.GetList();
        Move();
    }

    private void GetReference()
    {
        animationHandler = FindObjectOfType<AnimationHandler>();
        alienManager = FindObjectOfType<AlienManager>();
    }

    virtual protected void Update()
    {
        if (typeBullet == 1)
        {
            if (chooseAlien == null) chooseAlien = FindAlien();
            animationHandler.OnTargetAnimation(chooseAlien.gameObject);
            transform.position = Vector2.MoveTowards(transform.position,
            chooseAlien.transform.position, -moveSpeed * Time.deltaTime);
            minn = 10;
            // else Destroy(gameObject);
        }
    }


    private Alien FindAlien()
    {
        Alien temp = new Alien();
        for (int i = ship.Count - 1; i >= 0; i--)
        {
            if (ship[i].GetAlienHealth() < minn)
            {
                minn = ship[i].GetAlienHealth();
                temp = aliens[i];
            }
        }
        return temp;
    }

    virtual protected void Move()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * moveSpeed;
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
        if (typeBullet == 3)
        {
            for (int i = aliens.Length - 1; i >= 0; i--)
            {
                if (aliens[i].name == other.name) aliens[i].TakeDamage(aliens[i].GetAlienHealth());
            }
        }
        else if (typeBullet == 2)
        {
            Vector2 pos = other.gameObject.GetComponent<Ship>().GetCoordinate();
            Debug.Log($"Coordinate: {pos.x} {pos.y}");
            Debug.Log(pos.x);
            Debug.Log(pos.y);
            for (int i = 0; i < 8; i++)
            {
                int dirX = (int)pos.x + dx[i];
                int dirY = (int)pos.y + dy[i];
                if (dirX >= 0 && dirX < 5 && dirY >= 0 && dirY < 5 && alienManager.GetAlienInMatrix(dirX, dirY) != null)
                {
                    var alien = alienManager.GetAlienInMatrix(dirX, dirY);
                    alien.TakeDamage(alien.GetAlienHealth());
                }
            }
        }
        else
        {
            if (typeBullet == 1) animationHandler.ExitTargetAnimation(chooseAlien.gameObject);
            var enemy = other.GetComponent<IHealth>();
            enemy.TakeDamage(damage);
        }
    }
}