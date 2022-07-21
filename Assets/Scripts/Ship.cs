using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ship : MonoBehaviour, IHealth, IHunter
{
    [SerializeField]
    protected int speed = 10;
    public GameObject bullet;
    protected Rigidbody2D rb;
    [SerializeField]
    private Sprite explodeObject;
    [SerializeField]
    private AudioClip shipExplosion;
    protected bool canShoot = true;
    [SerializeField]
    protected Gun gun;
    [SerializeField]
    private float reloadTime = 1f;
    public UnityEvent<Ship> OnDeath = new UnityEvent<Ship>();

    virtual public void Die()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = explodeObject;
        SoundManager.Instance.PlayOneShot(shipExplosion);
        Destroy(gameObject, 0.1f);
        OnDeath?.Invoke(this);
    }

    public abstract void TakeDamage(int damage);
    private IEnumerator ReloadIEnumerator()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    public void Shoot()
    {
        gun.Shoot();
        Reload();
    }

    public void Reload()
    {
        StartCoroutine(ReloadIEnumerator());
    }
}
