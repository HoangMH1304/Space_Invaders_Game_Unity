using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitHearts : MonoBehaviour
{
    private Player ship;
    public GameObject[] Hearts;
    void Start()
    {
        ship = GameObject.Find("SpaceShip").GetComponent<Player>();
        // ShowHealth();
    }


}
