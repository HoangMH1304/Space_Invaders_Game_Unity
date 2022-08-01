using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContainer : MonoBehaviour
{
    [SerializeField]
    private List<PowerUp> powerUps;

    enum PowerUps
    {
        ChangeGun,
        Shield,
        BonusHealth
    }

    public PowerUp RandomPowerUp()
    {
        int index = Random.Range(0, powerUps.Count * 100) % powerUps.Count;
        Debug.Log($"Index: {index}");
        return powerUps[index];
    }

    // private void ChoosePowerUp()
    // {
    //     int i = RandomPowerUp();
    //     switch (i)
    //     {
    //         case (int)PowerUps.ChangeGun:
    //             Debug.Log("Change Gun");
    //             break;
    //         case (int)PowerUps.Shield:
    //             Debug.Log("Shield");
    //             break;
    //         case (int)PowerUps.BonusHealth:
    //             Debug.Log("Bonus Health");
    //             break;
    //     }
    //     powerUps[i].gameObject.SetActive(true);
    // }
}
