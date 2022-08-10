using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILastSceneHandler : MonoBehaviour
{
    private GameManager gameManager;

    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null) Destroy(canvas);
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateUI();
    }

    void UpdateUI()
    {
        var textUI = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();
        if (GameManager.Instance.GetResultState() == true)
        {
            textUI.text = "You Win";
        }
        else
        {
            textUI.text = "You Lose";
        }
    }
}
