using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    public AudioClip bulletFire;
    public AudioClip shipExplosion;
    private AudioSource soundEffectAudio;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        // AudioSource theSource = GetComponent<AudioSource>();
        // soundEffectAudio = theSource;
        soundEffectAudio = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
