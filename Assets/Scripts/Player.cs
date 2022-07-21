using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private const float topRange = -12f;
    private const float bottomRange = -30f;
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float smooth = 10f;
    private int health = 3;
    private bool dead = false;
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
        if (canShoot) Shoot();
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

    override public void TakeDamage(int damage)
    {
        if (dead)
            return;
        health -= damage;
        uIHandler.UpdateHealth();
        if (health <= 0)
        {
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