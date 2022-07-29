using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private const float TOP_RANGE = -12f;
    private const float BOTTOM_RANGE = -30f;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float smooth = 10f;
    private bool dead = false;
    private UIHandler uIHandler;
    private SlowEffect slowEffect;
    private SpriteRenderer spriteRenderer;
    float time = 0;

    void Start()
    {
        Init();
        uIHandler.UpdateHealth();
        // slowEffect.TurnColor()
    }

    private void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        uIHandler = FindObjectOfType<UIHandler>();
        health = GameManager.Instance.GetSpaceShipHealth();
        slowEffect = FindObjectOfType<SlowEffect>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void ChangeGun()
    {
        var gunStore = GameObject.Find("SpaceShipGunContainer").GetComponent<GunStore>();
        Gun temp = gunStore.RandomGun();
        while (gun == temp)
        {
            temp = gunStore.RandomGun();
        }
        gun = temp;
    }

    void FixedUpdate()
    {
        IsFreeze();
        MoveSpaceShip();
        Shoot();
    }

    private void IsFreeze()
    {
        if (smooth == 1)
        {
            // slowEffect.TurnColor();
            time += Time.deltaTime;
        }
        if (time >= 5.5f)
        {
            // slowEffect.OriginColor();
            smooth = 10;
            time = 0;
        }
    }

    public void TurnIntoFreeze()
    {
        smooth = 1;
    }

    private void MoveSpaceShip()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        if (mouseWorldPosition.y > TOP_RANGE || mouseWorldPosition.y < BOTTOM_RANGE) mouseWorldPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, mouseWorldPosition, Time.deltaTime * smooth);
    }

    override public void TakeDamage(int damage)
    {
        if (dead)
            return;
        health -= damage;
        uIHandler.UpdateHealth();
        if (health <= 0)
        {
            slowEffect.OnDead();
            dead = true;
            Die();
            var changeScene = mainCamera.GetComponent<ChangeScene>();
            changeScene.ChangeLastScene();
        }
    }
}