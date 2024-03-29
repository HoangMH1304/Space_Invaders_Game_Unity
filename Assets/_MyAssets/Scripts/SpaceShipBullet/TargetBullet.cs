using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetBullet : Bullet
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject deathPos;
    // [SerializeField]
    // private Sprite deathImage;
    [SerializeField]
    private int health = 2;
    private GameObject targetIcon;
    private const int BIG_NUM = 100;
    private const string WALL_TAG = "Wall";
    private Alien chooseAlien;
    // private GameObject temp = null;
    private Rigidbody2D rigidBody;
    private Vector3 position;
    int minn = BIG_NUM;

    private void Awake()
    {
        timeToExplode = 5f;
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // if (chooseAlien == null) chooseAlien = FindAlien();
        // if (chooseAlien == null)
        // {
        //     var image = GetComponent<SpriteRenderer>();
        //     image.sprite = deathImage;
        //     Destroy(gameObject, 0.1f); //
        //     return;
        // }
        // transform.position = Vector2.MoveTowards(transform.position,
        // chooseAlien.transform.position, moveSpeed * Time.deltaTime);

        Vector3 moveDirection = new Vector3();
        if (chooseAlien == null) chooseAlien = FindAlien();
        if (chooseAlien == null)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            position, moveSpeed * Time.deltaTime);
            moveDirection = (position - transform.position).normalized;
            if (transform.position == position)
            {
                Die();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
            chooseAlien.transform.position, moveSpeed * Time.deltaTime);
            position = chooseAlien.transform.position;
            moveDirection = (chooseAlien.transform.position - transform.position).normalized;
        }

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // if (moveDirection != Vector3.zero)
        // {
        //     float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // }

        minn = BIG_NUM;
        // else Destroy(gameObject);
    }

    private void Die()
    {
        var image = GetComponent<SpriteRenderer>();
        image.sprite = deathImage;
        image.gameObject.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject, 0.1f); //
    }

    private Alien FindAlien()
    {
        int index1 = 0;
        Alien targetAlien = null;
        for (int i = aliens.Length - 1; i >= 0; i--)
        {
            if (aliens[i].GetHealth() < minn)
            {
                minn = aliens[i].GetHealth();
                targetAlien = aliens[i];
                index1 = i;
            }
        }
        if (targetAlien != null)
        {
            aliens = aliens.Where((source, index) => index != index1).ToArray();
            GameObject[] junks = GameObject.FindGameObjectsWithTag("Aim");
            foreach (var junk in junks) Destroy(junk);
            targetIcon = Instantiate(target);
            Debug.Log("Aim");
            targetIcon.transform.SetParent(targetAlien.transform);
            targetIcon.transform.localPosition = new Vector2(0, 0);

        }
        return targetAlien;
    }

    protected override void HandleTriggerEnter(Collider2D other)
    {
        // if (GameObject.FindGameObjectWithTag("Aim") != null && chooseAlien.gameObject != null && other.gameObject != chooseAlien.gameObject)
        //     Destroy(targetIcon);
        if (other.tag == ENEMY_TAG)
        {
            DealDamage(other);
        }
        if (other.tag == SHIELD_TAG)
        {
            other.GetComponent<ShieldEffect>().OnDead();
            Destroy(other.gameObject, 0.1f);
        }
        if (other.name == "AlienBullet(Clone)")
        {
            timeToExplode -= (timeToExplode / health);
            health--;
            if (health <= 0)
            {
                Destroy(targetIcon);
                Die();
            }
        }
        if (other.tag == ALIEN_BULLET) return;
        Destroy(gameObject);
        Destroy(targetIcon);
    }

    override protected void DealDamage(Collider2D other)
    {
        other.GetComponent<Alien>().Kill();
    }
}