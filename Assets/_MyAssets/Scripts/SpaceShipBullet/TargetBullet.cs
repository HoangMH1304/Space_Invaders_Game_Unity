using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : Bullet
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject target1;
    private GameObject targetIcon;
    private const int BIG_NUM = 100;
    private Alien chooseAlien;
    // private GameObject temp = null;
    private Rigidbody2D rigidBody;
    int minn = BIG_NUM;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    protected void Update()
    {
        if (chooseAlien == null) chooseAlien = FindAlien();
        if (chooseAlien == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position,
        chooseAlien.transform.position, moveSpeed * Time.deltaTime);
        // if (transform.position != Vector3.zero)
        // {
        //     Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, transform.position);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        // }
        // Vector2 moveDirection = transform.position.normalized;
        // if (moveDirection != Vector2.zero)
        // {
        //     float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // }

        minn = BIG_NUM;
        // else Destroy(gameObject);
    }

    // private Alien FindAlien()
    // {
    //     Alien targetAlien = null;
    //     for (int i = aliens.Length - 1; i >= 0; i--)
    //     {
    //         if (aliens[i].GetHealth() < minn)
    //         {
    //             minn = aliens[i].GetHealth();
    //             targetAlien = aliens[i];
    //         }
    //     }
    //     if (targetAlien != null)
    //     {
    //         // if (temp != null) temp.SetActive(false);
    //         if (temp != null && temp != targetAlien) Destroy()


    //         // var target = targetAlien.transform.Find("Target");
    //         // temp = target.gameObject;
    //         GameObject targetIcon = Instantiate(targetAlien.gameObject);
    //         targetIcon.transform.SetParent(targetAlien.transform);
    //         temp = targetIcon;
    //         // target.gameObject.SetActive(true);
    //     }
    //     return targetAlien;
    // }

    private Alien FindAlien()
    {
        Alien targetAlien = null;
        for (int i = aliens.Length - 1; i >= 0; i--)
        {
            if (aliens[i].GetHealth() < minn)
            {
                minn = aliens[i].GetHealth();
                targetAlien = aliens[i];
            }
        }
        if (targetAlien != null)
        {
            GameObject[] junks = GameObject.FindGameObjectsWithTag("Aim");
            foreach (var junk in junks) Destroy(junk);
            targetIcon = Instantiate(target1);
            Debug.Log("Aim");
            targetIcon.transform.SetParent(targetAlien.transform);
            targetIcon.transform.localPosition = new Vector2(0, 0);
        }
        return targetAlien;
    }

    protected override void HandleTriggerEnter(Collider2D other)
    {
        if (other.gameObject != chooseAlien.gameObject)
            Destroy(targetIcon);
        if (other.tag == ENEMY_TAG)
        {
            DealDamage(other);
        }
        if (other.tag == SHIELD_TAG)
        {
            Destroy(other.gameObject);
        }
        if (other.tag == ENERGY_SHIELD)
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    override protected void DealDamage(Collider2D other)
    {
        if (other.gameObject != chooseAlien.gameObject) Destroy(targetIcon);
        other.GetComponent<Alien>().Kill();
    }
}