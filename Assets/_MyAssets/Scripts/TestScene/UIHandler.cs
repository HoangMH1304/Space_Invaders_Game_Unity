using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UIHandler : MonoBehaviour
{
    private Player ship;
    private AlienManager alienManager;
    [SerializeField]
    private GameObject incresePoint;
    [SerializeField]
    private List<GameObject> hearts;
    const int WAVE = 3;

    private void Awake()
    {
        Init();
        alienManager.OnCall.AddListener(CountWave);
    }

    private void Start()
    {
        UpdateHealth();
    }
    private void Init()
    {
        GetReference();
        UpdateReference();
    }

    private void UpdateReference()
    {
        UpdateValue("Score", GameManager.Instance.GetScore());
        //Write back again
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
        if (ship.GetHealth() < 3)
        {
            int hp = ship.GetHealth();
            StartCoroutine(Delay());
            hearts[hp].SetActive(true);
            GameManager.Instance.UpdatePlayerHealth(hp + 1);
            ship.SetHealth(ship.GetHealth() + 1);
        }
    }

    IEnumerator Delay()
    {
        incresePoint.SetActive(true);
        yield return new WaitForSeconds(2);
        incresePoint.SetActive(false);
    }
}
