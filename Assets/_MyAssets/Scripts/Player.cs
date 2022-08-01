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
    private bool isFasterShoot = false;
    private UIHandler uIHandler;
    private SpaceShipEffect spaceshipEffect;
    private SpriteRenderer spriteRenderer;
    private float time = 0f;
    private float reloadShoot;
    bool isChangeReloadTime = false;
    bool isEnableMagnet = false;

    void Start()
    {
        Init();
        reloadShoot = gun.GetReloadTime();
        uIHandler.UpdateHealth();
    }

    private void Init()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        uIHandler = FindObjectOfType<UIHandler>();
        health = GameManager.Instance.GetSpaceShipHealth();
        spaceshipEffect = FindObjectOfType<SpaceShipEffect>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void ChangeGun()
    {
        if (isChangeReloadTime == true) gun.SetReloadTime(reloadShoot * 2);
        var gunStore = GameObject.Find("SpaceShipGunContainer").GetComponent<GunStore>();
        Gun temp = gunStore.RandomGun();
        while (gun == temp)
        {
            temp = gunStore.RandomGun();
        }
        gun = temp;
        reloadShoot = gun.GetReloadTime();
    }

    public float GetReloadTime()
    {
        return reloadShoot;
    }

    public void SetReloadTime(float x)
    {
        gun.SetReloadTime(x);
        reloadShoot = x;
        isChangeReloadTime = true;
    }

    public void SetMagnetItem(bool condition)
    {
        isEnableMagnet = condition;
    }

    public bool GetMagnetItem()
    {
        return isEnableMagnet;
    }

    void FixedUpdate()
    {
        IsFreeze();
        MoveSpaceShip();
        if (isFasterShoot && TakeTime()) FasterShoot();
        else Shoot();
    }

    private bool TakeTime()
    {
        Alien[] aliens = null;
        aliens = FindObjectsOfType<Alien>();
        if (aliens.Length == 0)
        {
            isFasterShoot = false;
            return false;
        }
        return true;
    }

    public void SetCondition(bool condition)
    {
        isFasterShoot = condition;
    }

    private void IsFreeze()
    {
        if (smooth == 1)
        {
            time += Time.deltaTime;
        }
        if (time >= 5.5f)
        {
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
            spaceshipEffect.OnDead();
            dead = true;
            Die();
            var changeScene = mainCamera.GetComponent<ChangeScene>();
            changeScene.ChangeLastScene();
        }
    }
}