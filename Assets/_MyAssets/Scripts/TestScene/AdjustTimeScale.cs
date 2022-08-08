using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdjustTimeScale : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeTimeScale(float x)
    {
        Time.timeScale = x;
    }

    public void UpdateTextUi(float x)
    {
        var textUI = GameObject.Find("TimeScale").GetComponent<TextMeshProUGUI>();
        textUI.text = "Time Scale: " + x.ToString();
    }
}
