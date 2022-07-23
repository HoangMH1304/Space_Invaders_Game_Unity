using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UIHandler : MonoBehaviour
{
    private Player ship;
    private AlienManager alienManager;
    // private GameManager gameManager;
    [SerializeField]
    private GameObject incresePoint;
    [SerializeField]
    private List<GameObject> hearts;
    const int WAVE = 3;

    private void Awake()
    {
        Init();
        // if (alienManager == null)
        //     Debug.Log("alienManager null");
        // if (alienManager.OnCall == null)
        //     Debug.Log("oncall null");
        alienManager.OnCall.AddListener(CountWave);
        // alienManager.OnCall.AddListener((wave) =>
        // {
        //     Debug.Log($"on new waves callback!");
        // });

        // Debug.Log("Add listener");
    }

    private void Start()
    {
        UpdateHealth();
        Debug.Log(GameManager.Instance.GetSpaceShipHealth());
    }
    private void Init()
    {
        GetReference();
        UpdateReference();
    }

    private void UpdateReference()
    {
        // UpdateHealth();
        // UpdateValue("Score", gameManager.GetScore());
        // UpdateValue("Level", gameManager.GetLevel());

        UpdateValue("Score", GameManager.Instance.GetScore());
        UpdateValue("Level", GameManager.Instance.GetLevel());

    }

    private void GetReference()
    {
        ship = GameObject.Find("SpaceShip").GetComponent<Player>();
        // gameManager = FindObjectOfType<GameManager>();
        alienManager = FindObjectOfType<AlienManager>();
        // Debug.LogError($"alien manager: {alienManager.gameObject.name}");

    }

    public void DestroyButton()
    {
        alienManager.DestroyAliens();
    }

    public void CountWave(int waves)
    {
        // Debug.Log($"Update wave: {waves}");
        var textUI = GameObject.Find("Wave").GetComponent<TextMeshProUGUI>();
        textUI.text = (WAVE - waves).ToString() + " wave(s) left";
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

    public void IncreaseHealth()
    {
        incresePoint.SetActive(true);
        hearts[ship.GetHealth()].SetActive(true);
    }
}
