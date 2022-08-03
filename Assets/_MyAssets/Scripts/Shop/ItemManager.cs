using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    private const int MAX_HEALTH = 3;
    private Player player;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject magnet;
    private bool isPurchase = true;

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
                AddShield(item.quantity);
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
        if (isPurchase == true)
        {
            item.quantity++;
            GameManager.Instance.AddScore(-price);
        }
    }

    private void AddShield(int num)
    {
        GameObject player = GameObject.Find("SpaceShip");
        var energyShield = FindObjectOfType<EnergyShield>();
        if (energyShield == null)
        {
            Instantiate(shield, player.transform.position, Quaternion.identity);
            energyShield = FindObjectOfType<EnergyShield>();
        }
        energyShield.SetEndTime((num + 1) * 5);
        Debug.Log($"Time left: {(num + 1) * 5}");
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
        float speed = player.GetSpeedBullet();
        speed *= 1.1f;
        Debug.Log($"Bullet Speed: {speed}");
        player.SetSpeedBullet(speed);
    }
    private void IncreseReloadSpeed()
    {
        float reloadTime = player.GetReloadTime();
        reloadTime *= 0.9f;
        Debug.Log($"Reload Time: {reloadTime}");
        player.SetReloadTime(reloadTime);
    }
    private void MagnetItem()
    {
        player.SetMagnetItem(true);
        magnet.SetActive(true);
    }
}