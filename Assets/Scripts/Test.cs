using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private void Update() 
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        mouseWorldPosition.y = transform.position.y;
        transform.position = mouseWorldPosition;
    }
}
