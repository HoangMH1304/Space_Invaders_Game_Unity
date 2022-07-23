using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnUpDownVolume : MonoBehaviour
{
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceSFX;
    private GameManager gameManager;
    private SoundManager soundManager;
    private GameState gameState;
    private TextMeshProUGUI textMusicValue;
    private TextMeshProUGUI textSFXValue;
    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        audioSourceMusic = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        audioSourceSFX = this.GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }


    public void TurnUpDownMusic(float t)        //UI
    {
        soundManager.SetVolumeMusic(t);

    }

    public void TurnUpDownSFX(float t)          //UI
    {
        soundManager.SetVolumeSFX(t);
    }

    public void UpdateMusicValueText(float t)                //UI
    {
        textMusicValue = GameObject.Find("MusicText").GetComponent<TextMeshProUGUI>();
        int value = (int)(t * 100);
        textMusicValue.text = "Music: " + value.ToString();
    }

    public void UpdateSFXValueText(float t)                  //UI 
    {
        textSFXValue = GameObject.Find("SFXText").GetComponent<TextMeshProUGUI>();
        int value = (int)(t * 100);
        textSFXValue.text = "SFX: " + value.ToString();
    }
}
