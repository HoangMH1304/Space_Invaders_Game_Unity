using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipEffect : Effect
{
    public void TurnColor()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        float time = 0;
        while (true)
        {
            if (spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.blue;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            if (time > 5) break;
            yield return new WaitForSeconds(countdownTime);
            time += 0.5f;
            Debug.Log($"Time: {time}");
        }
    }

}
