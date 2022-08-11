using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ship : MonoBehaviour, IHealth, IHunter
{
    [SerializeField]
    protected float speed = 10f;
    protected Rigidbody2D rigidBody;
    [SerializeField]
    private AudioClip shipExplosion;
    protected bool canShoot = true;
    [SerializeField]
    protected Gun gun;
    public UnityEvent<Ship> OnDeath = new UnityEvent<Ship>();
    protected int health;
    protected AlienManager alienManager;
    private Vector2 coordinate;
    virtual public void Die()
    {
        SoundManager.Instance.PlayOneShot(shipExplosion);
        Destroy(gameObject, 0.2f);
        OnDeath?.Invoke(this);
    }

    // virtual public void SilentDie()
    // {
    //     Destroy(gameObject, 0.2f);
    //     OnDeath?.Invoke(this);
    // }

    public void SetHealth(int hp)
    {
        health = hp;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetCoordinate(Vector2 vt)
    {
        coordinate = vt;
    }

    public Vector2 GetCoordinate()
    {
        return coordinate;
    }

    public abstract void TakeDamage(int damage);

    virtual public void ChangeGun()
    {
        var gunStore = FindObjectOfType<GunStore>();
        gun = gunStore.RandomGun();
    }

    public void Shoot()
    {
        gun.Shoot();
    }
}