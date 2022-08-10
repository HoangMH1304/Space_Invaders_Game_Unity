using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicManager : MonoBehaviour
{
    [SerializeField]
    private GameObject newGameObject;
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Music") == null)
            Instantiate(newGameObject);
    }
}
