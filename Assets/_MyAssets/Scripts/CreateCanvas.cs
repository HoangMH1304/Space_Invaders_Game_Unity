using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject newGameObject;
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Canvas") == null)
            Instantiate(newGameObject);
    }
}
