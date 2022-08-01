using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortal : MonoBehaviour
{
    public void DivineBeing()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.tag = "Wall";
    }
}
