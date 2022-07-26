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
        // int index = Random.Range(0, guns.Count);
        int index = Random.Range(0, guns.Count * 100) % guns.Count;
        Debug.Log($"Index: {index}");
        // return guns[index];
        return guns[3];
    }
}
