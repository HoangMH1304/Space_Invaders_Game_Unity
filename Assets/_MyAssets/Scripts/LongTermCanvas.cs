using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTermCanvas : MonoBehaviourSingleton<LongTermCanvas>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
