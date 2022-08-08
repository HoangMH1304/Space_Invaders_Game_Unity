using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTermCanvas : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
