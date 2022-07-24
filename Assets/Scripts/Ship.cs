using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ship : MonoBehaviour, IHealth, IHunter
{
    [SerializeField]
    protected int speed = 10;
    protected Rigidbody2D rb;
    // [SerializeField]
    // private Sprite explodeObject;
    [SerializeField]
    private AudioClip shipExplosion;
    protected bool canShoot = true;
    [SerializeField]
    protected Gun gun;
    private GunStore gunStore;

    // [SerializeField]
    // protected List<Gun> guns;
    [SerializeField]
    private float reloadTime = 1f;
    public UnityEvent<Ship> OnDeath = new UnityEvent<Ship>();

    virtual public void Die()
    {
        // var spriteRender = GetComponent<SpriteRenderer>();
        // spriteRender.sprite = explodeObject;
        SoundManager.Instance.PlayOneShot(shipExplosion);
        Destroy(gameObject, 0.2f);
        OnDeath?.Invoke(this);
    }

    public bool GetChance(int rate)
    {
        return Random.Range(1, 100) <= rate;
    }


    public abstract void TakeDamage(int damage);

    public void ChangeGun()
    {
        var gunStore = FindObjectOfType<GunStore>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            gun = gunStore.RandomGun();

        }
    }

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
