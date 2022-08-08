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
        musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    // public void SetMusicSliderChange(float value)
    // {
    //     PlayerPrefs.SetFloat("Music", value);
    // }

    public void GetSFXSliderChange()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
    }

    // public void SetSFXSliderChange(float value)
    // {
    //     PlayerPrefs.SetFloat("SFX", value);
    // }
}
