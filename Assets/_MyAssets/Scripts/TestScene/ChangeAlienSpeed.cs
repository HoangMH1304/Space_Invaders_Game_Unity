using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlienSpeed : MonoBehaviour
{
    public void IdleAlien(bool idle)
    {
        if (idle == true)
        {
            float t = TestManager.Instance.GetOldAlienSpeed();
            TestManager.Instance.SetAlienSpeed(t);
        }
        else
        {
            TestManager.Instance.SetAlienSpeed(0);
        }
        // if (TestManager.Instance.GetAlienSpeed() != 0)
        // {
        //     TestManager.Instance.SetAlienSpeed(0);
        // }
        // else
        // {
        //     float t = TestManager.Instance.GetOldAlienSpeed();
        //     TestManager.Instance.SetAlienSpeed(t);
        // }
    }
}
