using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestChance : MonoBehaviour
{

    // private int chance = 5;
    public void SetChance(float t)
    {
        TestManager.Instance.SetAlienShootRate((int)t);
    }

    public void SetUIText(float t)
    {
        var textUI = GameObject.Find("Percent").GetComponent<TextMeshProUGUI>();
        textUI.text = "1 / " + ((int)t).ToString();
    }
}
