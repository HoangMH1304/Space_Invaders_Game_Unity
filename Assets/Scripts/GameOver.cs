using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateUI();
    }

    void UpdateUI()
    {
        var textUI = FindObjectOfType<TextMeshProUGUI>();
        textUI.text = gameManager.GetResult();
    }
}
