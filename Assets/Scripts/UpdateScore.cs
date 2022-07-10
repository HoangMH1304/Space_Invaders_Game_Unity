using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public void IncreseScore()
    {
        var textUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        int score = int.Parse(textUI.text);
        score += 10;
        textUI.text = score.ToString();
    }
}
