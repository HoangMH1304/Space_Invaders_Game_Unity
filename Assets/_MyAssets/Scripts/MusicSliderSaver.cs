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

    public void GetSFXSliderChange()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
    }
}
