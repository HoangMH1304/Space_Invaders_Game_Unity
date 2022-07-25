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


    public void Shoot()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            Instantiate(bullets[i], ship.transform.position, Quaternion.identity);
        }
        SoundManager.Instance.PlayOneShot(fireAudioClip);
    }


}
