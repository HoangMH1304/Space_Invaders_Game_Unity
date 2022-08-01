using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private const int MAX_HEALTH = 3;
    private Player player;
    [SerializeField]
    private GameObject shield;
    bool isPurchase = true;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void Buy(Item item)
    {
        int price = item.price;
        if (GameManager.Instance.GetScore() < price)
        {
            return;
        }
        switch (item.id)
        {
            case 0:
                AddShield();
                break;
            case 1:
                IncreseHealth();
                break;
            case 2:
                IncreseBulletSpeed();
                break;
            case 3:
                IncreseReloadSpeed();
                break;
            case 4:
                MagnetItem();
                break;
            default:
                break;
        }
        if (isPurchase == true) GameManager.Instance.AddScore(-price);
    }

    private void AddShield()
    {
        GameObject player = GameObject.Find("SpaceShip");
        Instantiate(shield, player.transform.position, Quaternion.identity);
    }

    private void IncreseHealth()
    {
        var player = FindObjectOfType<Player>();
        if (player.GetHealth() == MAX_HEALTH)
        {
            isPurchase = false;
            return;
        }
        var uIHandler = FindObjectOfType<UIHandler>();
        uIHandler.IncreaseHealth();
    }

    private void IncreseBulletSpeed()
    {
        player.SetCondition(true);
    }
    private void IncreseReloadSpeed()
    {
        float reloadTime = player.GetReloadTime();
        reloadTime /= 2;
        player.SetReloadTime(reloadTime);
    }
    private void MagnetItem()
    {
        throw new NotImplementedException();
    }

}
