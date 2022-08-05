using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    [SerializeField]
    List<GameObject> bullets;
    [SerializeField]
    private AudioClip fireAudioClip;
    [SerializeField]
    private float reloadTime;
    private float bulletSpeed;
    private bool canShoot = true;

    private void Start()
    {
        reloadTime = GunManager.Instance.GetReloadTime();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                GameObject bullet = Instantiate(bullets[i], ship.transform.position, Quaternion.identity);
            }
            SoundManager.Instance.PlayOneShot(fireAudioClip);
        }
        else return;
        StartCoroutine(ReloadIEnumerator());
    }

    private IEnumerator ReloadIEnumerator()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    public void SetReloadTime(float x)
    {
        reloadTime = x;
    }

    public float GetReloadTime()
    {
        return reloadTime;
    }

    public void SetBulletSpeed(float x)
    {
        bullets[0].GetComponent<Bullet>().SetSpeed(x);
    }

    public float GetBulletSpeed()
    {
        return bullets[0].GetComponent<Bullet>().GetSpeed();
    }
}