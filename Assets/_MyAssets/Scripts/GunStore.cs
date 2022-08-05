using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStore : MonoBehaviour
{
    enum Guns
    {
        Gun1Shot,
        Gun2Shot,
        GunDestroyAllType,
        TargetGun,
        BoombGun
    }
    [SerializeField]
    private List<Gun> guns;

    public Gun ChooseGun(int index)
    {
        return guns[index];
    }
    public Gun RandomGun()
    {
        int index = Random.Range(0, guns.Count * 100) % guns.Count;
        // Debug.Log($"Index: {index}");
        switch (index)
        {
            case (int)Guns.Gun1Shot:
                Debug.Log("Gun1Shot");
                break;
            case (int)Guns.Gun2Shot:
                Debug.Log("Gun2Shot");
                break;
            case (int)Guns.GunDestroyAllType:
                Debug.Log("GunDestroyAllType");
                break;
            case (int)Guns.TargetGun:
                Debug.Log("TargetGun");
                break;
            case (int)Guns.BoombGun:
                Debug.Log("BombGun");
                break;
        }
        return guns[index];
        // return guns[2];
    }
}