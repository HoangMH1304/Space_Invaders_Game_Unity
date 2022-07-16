using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePlayMusic : MonoBehaviour
{
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
