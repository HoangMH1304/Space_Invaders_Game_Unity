using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStore : MonoBehaviour
{
    [SerializeField]
    private List<Gun> guns;
    public int index;
    public Gun RandomGun()
    {
        return guns[Random.Range(1, guns.Count)];
    }
}
