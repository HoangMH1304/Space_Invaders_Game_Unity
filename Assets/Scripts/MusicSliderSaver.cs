using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicSliderSaver : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;
    public void GetMusicSliderChange()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicSliderSaver");
    }

    public void SetMusicSliderChange(float value)
    {
        PlayerPrefs.SetFloat("MusicSliderSaver", value);
    }

    public void GetSFXSliderChange()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXSliderSaver");
    }

    public void SetSFXSliderChange(float value)
    {
        PlayerPrefs.SetFloat("SFXSliderSaver", value);
    }
}
