using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20f, 20f),
        Mathf.Clamp(transform.position.y, -40f, 40f), transform.position.z);
    }
}
