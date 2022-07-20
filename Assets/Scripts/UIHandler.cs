using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UIHandler : MonoBehaviour
{
    private Player ship;
    private GameManager gameManager;
    [SerializeField]
    private List<GameObject> hearts;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GetReference();
        UpdateReference();
    }

    private void UpdateReference()
    {
        UpdateHealth();
        UpdateValue("Score", gameManager.GetScore());
        UpdateValue("Level", gameManager.GetLevel());

    }

    private void GetReference()
    {
        ship = GameObject.Find("SpaceShip").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    public void UpdateUIVolumeMusic(float value)
    {
        int intergerValue = (int)(value * 100);
        var textUI = GameObject.Find("MusicText").GetComponent<TextMeshProUGUI>();
        textUI.text = "Music: " + intergerValue.ToString();
    }

    public void UpdateUIVolumeSFX(float value)
    {
        int intergerValue = (int)(value * 100);
        var textUI = GameObject.Find("SFXText").GetComponent<TextMeshProUGUI>();
        textUI.text = "SFX: " + intergerValue.ToString();
    }
}
