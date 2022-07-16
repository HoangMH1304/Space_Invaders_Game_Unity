using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    int score = 0;
    public void IncreseScore()
    {
        var textUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score += 10;
        textUI.text = "Score: " + score;
    }
}
