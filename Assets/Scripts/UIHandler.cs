using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UIHandler : MonoBehaviour
{
    private Player ship;
    int score = 0;
    [SerializeField]
    private List<GameObject> hearts;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ship = GameObject.Find("SpaceShip").GetComponent<Player>();
        UpdateHealth();
    }

    public void UpdateScore()
    {
        var textUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        textUI.text = $"Score: {score}";
    }



    public void UpdateHealth()
    {
        for (var i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < ship.GetHealth());
        }
    }
}
