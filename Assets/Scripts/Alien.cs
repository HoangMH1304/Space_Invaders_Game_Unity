using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed = 10f;
    public GameObject alienBullet;
    private Rigidbody2D rb;

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Instantiate(alienBullet, transform.position, Quaternion.identity);
    }
}
