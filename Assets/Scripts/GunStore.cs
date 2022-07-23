using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunStore : MonoBehaviour
{
    [SerializeField]
    private List<Gun> guns;

    public Gun RandomGun()
    {

        return guns[Random.Range(1, guns.Count)];
    }
}
