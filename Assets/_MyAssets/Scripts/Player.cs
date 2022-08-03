using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Ship
{
    private const float TOP_RANGE = -12f;
    private const float BOTTOM_RANGE = -30f;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    // private float smooth = 10f;
    private bool dead = false;
    private Touch touch;
    private UIHandler uIHandler;
    private SpaceShipEffect spaceshipEffect;
    private SpriteRenderer spriteRenderer;
    private float time = 0f;
    private float reloadShoot;    //-10% reload time
    private float bulletSpeed;    //+10% bullet speed
    bool isChangeReloadTime = false;
    bool isEnableMagnet = false;

    void Start()
    {
        GetReference();
        Init();
    }

    void Update()
    {
        IsFreeze();
        // MoveSpaceShip1();
        MoveSpaceShip();
        Shoot();
    }

    private void GetReference()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        uIHandler = FindObjectOfType<UIHandler>();
        spaceshipEffect = FindObjectOfType<SpaceShipEffect>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Init()
    {
        // speed = 1;
        speed = 10f;
        health = GameManager.Instance.GetSpaceShipHealth();
        reloadShoot = gun.GetReloadTime();
        bulletSpeed = gun.GetBulletSpeed();
        uIHandler.UpdateHealth();
    }

    public override void ChangeGun()
    {
        // if (isChangeReloadTime == true) gun.SetReloadTime(reloadShoot * 2);
        var gunStore = GameObject.Find("SpaceShipGunContainer").GetComponent<GunStore>();
        Gun temp = gunStore.RandomGun();
        while (gun == temp)
        {
            temp = gunStore.RandomGun();
        }
        gun = temp;
        reloadShoot = gun.GetReloadTime();
    }

    public void SetSpeed(float x)
    {
        speed = x;
    }

    public void ShowSpeedText(float x)
    {
        var textUI = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
        textUI.text = "Speed: " + x.ToString();
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

    public float GetSpeedBullet()
    {
        return bulletSpeed;
    }

    public void SetSpeedBullet(float x)
    {
        gun.SetBulletSpeed(x);
        bulletSpeed = x; //
        // isChangeReloadTime = true; //
    }

    public void SetMagnetItem(bool condition)
    {
        isEnableMagnet = condition;
    }

    public bool GetMagnetItem()
    {
        return isEnableMagnet;
    }

    private void IsFreeze()
    {
        if (speed == 1)
        {
            time += Time.deltaTime;
        }
        if (time >= 5.5f)
        {
            speed = 10;
            time = 0;
        }
    }

    public void TurnIntoFreeze()
    {
        speed = 1;
    }

    // private void IsFreeze()
    // {
    //     if (speed != oldSpeed)
    //     {
    //         time += Time.deltaTime;
    //     }
    //     if (time >= 5.5f)
    //     {
    //         speed = oldSpeed;
    //         time = 0;
    //     }
    // }

    // public void TurnIntoFreeze()
    // {
    //     speed /= 2;
    // }

    private void MoveSpaceShip()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        if (mouseWorldPosition.y > TOP_RANGE || mouseWorldPosition.y < BOTTOM_RANGE) mouseWorldPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, mouseWorldPosition, Time.deltaTime * speed);
    }

    private void MoveSpaceShip1()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x +
                touch.deltaPosition.x * Time.deltaTime * speed, transform.position.y +
                touch.deltaPosition.y * Time.deltaTime * speed, transform.position.z);
            }
        }
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