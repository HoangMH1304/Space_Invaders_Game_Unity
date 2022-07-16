using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    private ChangeScene changeScene;

    void Start()
    {
        changeScene = GameObject.Find("Main Camera").GetComponent<ChangeScene>();

    }
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Alien") == null)
        {
            changeScene.ChangeNextScene();
        }
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            changeScene.ChangeLastScene();
        }
    }
}
