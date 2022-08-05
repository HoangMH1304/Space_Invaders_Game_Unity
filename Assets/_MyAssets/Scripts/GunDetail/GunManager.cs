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

    private void InitData()
    {
        gunState = new GunState();
    }
}
