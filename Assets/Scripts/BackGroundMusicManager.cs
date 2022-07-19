using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;
    private void Start()
    {
        if (GameObject.Find("Music(Clone)") == null)
            Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity);
    }
}
