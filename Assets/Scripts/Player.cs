using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    private const float topRange = -12f;
    private const float bottomRange = -30f;
    public float moveSpeed;
    public GameObject bullet;
    private Rigidbody2D rb;
    [SerializeField]
    private float secToFire = 1f;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Sprite explodeShip;
    [SerializeField]
    private AudioClip shipExplosion;

    [SerializeField]
    private float smooth = 10f;
    private int health = 3;
    private bool dead = false;
    bool canShoot = true;
    private UIHandler uIHandler;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        uIHandler = GameObject.FindObjectOfType<UIHandler>();
        health = GameManager.Instance.GetSpaceShipHealth();
    }

    void FixedUpdate()
    {
        MoveSpaceShip();
        if (canShoot) StartCoroutine(SpawnBullet());
        // health = GameManager.Instance.GetSpaceShipHealth();
    }

    private void MoveSpaceShip()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        // mouseWorldPosition.y = transform.position.y;
        if (mouseWorldPosition.y > topRange || mouseWorldPosition.y < bottomRange) mouseWorldPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, mouseWorldPosition, Time.deltaTime * smooth);
    }
    private IEnumerator SpawnBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.bulletFire);
        canShoot = false;
        yield return new WaitForSeconds(secToFire);
        canShoot = true;
    }

    public void TakeDamage(int damage)
    {
        if (dead)
            return;
        health -= damage;
        uIHandler.UpdateHealth();
        if (health <= 0)
        {
            dead = true;
            Die();
        }
    }

    private void Die()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = explodeShip;
        SoundManager.Instance.PlayOneShot(shipExplosion);
        Destroy(gameObject, 0.1f);
    }

    public int GetHealth()
    {
        return health;
    }

}