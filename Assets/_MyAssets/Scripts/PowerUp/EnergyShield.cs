using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    private GameObject spaceship;
    private float time = 0;
    private float endTime = 5;
    void Start()
    {
        spaceship = GameObject.Find("SpaceShip");
    }

    public void SetEndTime(float t)
    {
        endTime = t;
    }

    public float GetEndTime()
    {
        return endTime;
    }
    void Update()
    {
        time += Time.deltaTime;
        // Debug.Log(time);
        if (time > endTime)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = spaceship.transform.position;
    }
}
