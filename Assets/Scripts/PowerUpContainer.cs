using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContainer : MonoBehaviour
{
    [SerializeField]
    private List<PowerUp> powerUps;

    public PowerUp RandomPowerUp()
    {
        int index = Random.Range(0, powerUps.Count * 100) % powerUps.Count;
        Debug.Log($"Index: {index}");
        return powerUps[index];
    }
}
