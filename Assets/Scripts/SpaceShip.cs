using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    private Rigidbody2D rb;
    [SerializeField]
    private float secToFire = 1f;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float smooth = 10f;
    bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveSpaceShip();
        if (canShoot) StartCoroutine(SpawnBullet());
    }

    private void MoveSpaceShip()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        mouseWorldPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, mouseWorldPosition, Time.deltaTime * smooth);
    }
    private IEnumerator SpawnBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManager.instance.PlayOneShot(SoundManager.instance.bulletFire);
        canShoot = false;
        yield return new WaitForSeconds(secToFire);
        canShoot = true;
    }
}
