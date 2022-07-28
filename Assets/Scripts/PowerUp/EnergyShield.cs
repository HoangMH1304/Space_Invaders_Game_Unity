using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    private GameObject spaceship;
    float time = 0;
    void Start()
    {
        spaceship = GameObject.Find("SpaceShip");
    }
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time > 5)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = spaceship.transform.position;
    }
}
