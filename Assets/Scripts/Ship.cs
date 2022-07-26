using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ship : MonoBehaviour, IHealth, IHunter
{
    [SerializeField]
    protected int speed = 10;
    protected Rigidbody2D rb;
    [SerializeField]
    private AudioClip shipExplosion;
    protected bool canShoot = true;
    [SerializeField]
    protected Gun gun;
    private GunStore gunStore;

    public UnityEvent<Ship> OnDeath = new UnityEvent<Ship>();
    private int health;
    private Vector2 coordinate;
    virtual public void Die()
    {
        SoundManager.Instance.PlayOneShot(shipExplosion);
        Destroy(gameObject, 0.2f);
        OnDeath?.Invoke(this);
    }

    public void SetAlienHealth(int hp)
    {
        health = hp;
    }

    public int GetAlienHealth()
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            gun = gunStore.RandomGun();

        }
    }

    public void Shoot()
    {
        gun.Shoot();
    }

}
