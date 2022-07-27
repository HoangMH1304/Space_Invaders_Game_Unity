using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private const float TOP_RANGE = -12f;
    private const float BOTTOM_RANGE = -30f;
    private const int RATE = 5;
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float smooth = 10f;
    private int health = 3;
    private bool dead = false;
    private UIHandler uIHandler;
    int index = 0;
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
        MoveSpaceShip();
        Shoot();
    }

    public int GetMoveSpeed()
    {
        return this.speed;
    }

    public void SetMoveSpeed(int moveSpeed)
    {
        speed = moveSpeed;
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
            var animator = GetComponent<Animator>();
            animator.enabled = !animator.enabled;
            dead = true;
            Die();
            var changeScene = mainCamera.GetComponent<ChangeScene>();
            changeScene.ChangeLastScene();
        }
    }

    public int GetHealth()
    {
        return health;
    }

}