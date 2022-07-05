using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        movingLeftPaddle();
    }

    void movingLeftPaddle()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -41.5f)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 41.5f)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
