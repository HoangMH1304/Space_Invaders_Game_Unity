using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private const string SHIELD_TAG = "Shield";

    // [SerializeField]
    // public Vector2 direction;
    // [SerializeField]
    // protected float moveSpeed = 30f;
    // void Start()
    // {
    //     var rigidbody = GetComponent<Rigidbody2D>();
    //     rigidbody.velocity = direction * moveSpeed;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == SHIELD_TAG) Destroy(other.gameObject);
        // Debug.Log("Trigger");
        var alien = other.GetComponent<Alien>();
        if (alien != null) other.GetComponent<Alien>().Kill();
        else Destroy(other.gameObject);
    }
}