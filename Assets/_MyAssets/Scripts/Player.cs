using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : Ship
{
    private const float TOP_RANGE = 20f;   //-12
    private const float BOTTOM_RANGE = -30f;  //-30
    private const float FREEZE_TIME = 3.5f;
    [SerializeField]
    private Camera mainCamera;
    private bool dead = false;
    private bool isFreeze = false;
    private Touch touch;
    private UIHandler uIHandler;
    private GunStore gunStore;
    private SpaceShipEffect spaceshipEffect;
    private SpriteRenderer spriteRenderer;
    private float time = 0f;
    private float oldSpeed;
    private float deltaX, deltaY;
    bool isEnableMagnet = false;

    void Start()
    {
        GetReference();
        Init();
    }

    void Update()
    {
        IsFreeze();
        // MoveSpaceShip1();     //touch
        MoveSpaceShip();
        if (!alienManager.IsEmpty()) Shoot();
    }

    private void MoveSpaceShip1()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            // touchPos.z = 0;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                case TouchPhase.Moved:
                    // rigidBody.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    Vector3 direction = touchPos - new Vector3(deltaX, deltaY, 0) - transform.position;
                    rigidBody.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);
                    break;
                case TouchPhase.Ended:
                    rigidBody.velocity = Vector2.zero;
                    break;
            }
        }
    }

    private void GetReference()
    {
        alienManager = FindObjectOfType<AlienManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        uIHandler = FindObjectOfType<UIHandler>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        spaceshipEffect = FindObjectOfType<SpaceShipEffect>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gunStore = GameObject.Find("SpaceShipGunContainer").GetComponent<GunStore>();
    }

    private void Init()
    {
        speed = 10f;
        // speed = 0.1f;
        oldSpeed = speed;
        gun = gunStore.ChooseGun(GunManager.Instance.GetGun());
        health = GameManager.Instance.GetSpaceShipHealth();
        uIHandler.UpdateHealth();
    }

    public override void ChangeGun()
    {
        float speedBefore = GetSpeedBullet();
        float reloadBefore = GetReloadTime();
        Gun temp = gunStore.RandomGun();
        while (gun == temp)
        {
            temp = gunStore.RandomGun();
        }
        gun = temp;
    }

    public void SetSpeed(float x)
    {
        speed = x;
    }

    public void ShowSpeedText(float x)
    {
        var textUI = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
        textUI.text = "Speed: " + ((int)x).ToString();
    }

    public float GetReloadTime()
    {
        return gun.GetReloadTime();
    }

    public void SetReloadTime(float x)
    {
        gun.SetReloadTime(x);
    }

    public float GetSpeedBullet()
    {
        return gun.GetBulletSpeed();
    }

    public void SetSpeedBullet(float x)
    {
        gun.SetBulletSpeed(x);
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
        // if (isFreeze == true)
        // {
        //     time += Time.deltaTime;
        // }
        // if (time >= FREEZE_TIME)
        // {
        //     isFreeze = false;
        //     time = 0;
        // }
        if (speed != oldSpeed)
        {
            time += Time.deltaTime;
        }
        if (time >= 5.5f)
        {
            speed = oldSpeed;
            time = 0;
        }
    }

    public void TurnIntoFreeze()
    {
        // isFreeze = true;
        speed /= 10;
    }

    private void MoveSpaceShip()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        if (mouseWorldPosition.y > TOP_RANGE || mouseWorldPosition.y < BOTTOM_RANGE) mouseWorldPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, mouseWorldPosition, Time.deltaTime * speed);
    }


    override public void TakeDamage(int damage)
    {
        if (dead)
            return;
        health -= damage;
        Handheld.Vibrate();
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