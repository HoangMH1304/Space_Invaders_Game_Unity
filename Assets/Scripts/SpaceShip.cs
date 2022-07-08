using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate() 
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDirection * moveSpeed, 0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            SoundManager.instance.PlayOneShot(SoundManager.instance.bulletFire);
        }
    }

}
