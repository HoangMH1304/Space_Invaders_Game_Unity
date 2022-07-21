using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePlayMusic : MonoBehaviourSingleton<ContinuePlayMusic>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
