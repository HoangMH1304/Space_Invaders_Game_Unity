using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviourSingleton<SoundManager>
{
    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    private AudioSource soundEffectAudio;
    private UIHandler uIHandler;
    private TurnUpDownVolume changeVolume;
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceSFX;
    private SoundState soundState;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    private void Init()
    {
        InitData();
        GetReferences();
    }

    public void InitData()
    {
        soundState = new SoundState();
        soundState.volumeMusic = 0.5f;
        soundState.volumeSFX = 0.5f;
    }

    private void GetReferences()
    {
        soundEffectAudio = GetComponent<AudioSource>();
        uIHandler = FindObjectOfType<UIHandler>();
        changeVolume = FindObjectOfType<TurnUpDownVolume>();
        audioSourceMusic = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        audioSourceSFX = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    //getter, setter music
    public float GetVolumeMusic()
    {
        return soundState.volumeMusic;
    }

    public void SetVolumeMusic(float x)
    {
        Debug.Log($"SetVolumeMusic: {x}");
        soundState.volumeMusic = x;
        audioSourceMusic.volume = x;
    }

    //getter, setter sfx
    public float GetVolumeSFX()
    {
        return soundState.volumeSFX;
    }

    public void SetVolumeSFX(float x)
    {
        soundState.volumeSFX = x;
        audioSourceSFX.volume = x;
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
