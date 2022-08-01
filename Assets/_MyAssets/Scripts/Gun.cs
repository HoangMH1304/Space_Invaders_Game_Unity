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
    private bool canShoot = true;

    public void NewShoot()
    {
        if (canShoot)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                GameObject bullet = Instantiate(bullets[i], ship.transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().NewSpeed();
            }
            SoundManager.Instance.PlayOneShot(fireAudioClip);
        }
        else return;
        StartCoroutine(ReloadIEnumerator());
    }


    public void Shoot()
    {
        if (canShoot)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                Instantiate(bullets[i], ship.transform.position, Quaternion.identity);
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
}