using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviourSingleton<GunManager>
{
    [SerializeField]
    private GunState gunState;

    protected override void Awake()
    {
        base.Awake();
        InitData();
    }

    public void InitData()
    {
        gunState = new GunState();
        gunState.bulletSpeed = 15f;
        gunState.reloadTime = 2f;
        gunState.gunIndex = 0;
    }

    public void SetSpeed(float speed)
    {
        gunState.bulletSpeed = speed;
    }

    public float GetSpeed()
    {
        return gunState.bulletSpeed;
    }

    public void SetReloadTime(float reloadTime)
    {
        gunState.reloadTime = reloadTime;
    }

    public float GetReloadTime()
    {
        return gunState.reloadTime;
    }

    public void ChangeGun(int index)
    {
        gunState.gunIndex = index;
    }

    public int GetGun()
    {
        return gunState.gunIndex;
    }
}
