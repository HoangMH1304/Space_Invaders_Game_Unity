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
    private TextMeshProUGUI textMusicValue;
    private TextMeshProUGUI textSFXValue;
    float valueMusic;
    float valueSFX;
    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        audioSourceMusic = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        audioSourceSFX = this.GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void UpdateMusicSFXValue()
    {
        gameManager.SetVolumeMusic(audioSourceMusic.volume);
        gameManager.SetVolumeSFX(audioSourceSFX.volume);
    }

    public void TurnUpDownMusic(float t)
    {
        audioSourceMusic.volume = t;
    }

    public void TurnUpDownSFX(float t)
    {
        audioSourceSFX.volume = t;
    }

    public void UpdateMusicValueText(float t)
    {
        textMusicValue = GameObject.Find("MusicText").GetComponent<TextMeshProUGUI>();
        int value = (int)(t * 100);
        textMusicValue.text = "Music: " + value.ToString();
    }

    public void UpdateSFXValueText(float t)
    {
        textSFXValue = GameObject.Find("SFXText").GetComponent<TextMeshProUGUI>();
        int value = (int)(t * 100);
        textSFXValue.text = "SFX: " + value.ToString();
    }
}
