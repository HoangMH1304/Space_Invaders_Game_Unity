using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UIHandler : MonoBehaviour
{
    private Player ship;
    // int score = 0;
    [SerializeField]
    private List<GameObject> hearts;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ship = GameObject.Find("SpaceShip").GetComponent<Player>();
        var value = GameObject.Find("GameManager").GetComponent<GameManager>();
        UpdateHealth();
        UpdateValue("Score", value.GetScore());
        UpdateValue("Level", value.GetLevel());
    }

    public void UpdateValue(string target, int value)
    {
        var textUI = GameObject.Find(target).GetComponent<TextMeshProUGUI>();
        textUI.text = target + " " + value.ToString();
    }

    public void UpdateHealth()
    {
        for (var i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < ship.GetHealth());
        }
    }
}
