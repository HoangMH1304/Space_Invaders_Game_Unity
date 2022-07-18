using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ship : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int speed = 10;
    public GameObject bullet;
    protected Rigidbody2D rb;
    [SerializeField]
    private Sprite explodeObject;
    [SerializeField]
    private AudioClip shipExplosion;
    public UnityEvent<Ship> OnDeath = new UnityEvent<Ship>();

    virtual public void Die()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = explodeObject;
        SoundManager.Instance.PlayOneShot(shipExplosion);
        Destroy(gameObject, 0.1f);
        OnDeath?.Invoke(this);
    }

    abstract public void TakeDamage(int damage);
}