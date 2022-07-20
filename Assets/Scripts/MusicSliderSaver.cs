using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicSliderSaver : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    public void GetSliderChange()
    {
        slider.value = PlayerPrefs.GetFloat("SliderSaver1");
    }

    public void SetSliderChange(float value)
    {
        PlayerPrefs.SetFloat("SliderSaver1", value);
    }
}
