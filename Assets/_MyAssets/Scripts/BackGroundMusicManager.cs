using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicManager : MonoBehaviour
{
    [SerializeField]
    private GameObject newGameObject;
    private void Start()
    {
        // if (GameObject.Find("Music(Clone)") == null)
        //     Instantiate(newGameObject, new Vector2(0, 0), Quaternion.identity);
        if (GameObject.FindGameObjectWithTag("Music") == null)
            Instantiate(newGameObject);
    }
}
