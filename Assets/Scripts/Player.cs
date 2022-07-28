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
    private Animator animator;
    float time = 0;

    void Start()
    {
        Init();
        uIHandler.UpdateHealth();
    }

    private void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        uIHandler = GameObject.FindObjectOfType<UIHandler>();
        health = GameManager.Instance.GetSpaceShipHealth();
        animator = GetComponent<Animator>();
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
            animator.SetBool("IsFreeze", true);
            time += Time.deltaTime;
        }
        if (time >= 5f)
        {
            smooth = 10;
            time = 0;
            animator.SetBool("IsFreeze", false);
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
            var animator = FindObjectOfType<AnimationHandler>();
            animator.OnDeadAnimation(this.gameObject);
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