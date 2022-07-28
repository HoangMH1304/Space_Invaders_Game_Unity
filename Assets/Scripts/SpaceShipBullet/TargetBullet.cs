using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : Bullet
{
    private Alien chooseAlien;
    int minn = 10;


    protected void Update()
    {
        if (chooseAlien == null) chooseAlien = FindAlien();
        // animationHandler.OnTargetAnimation(chooseAlien.gameObject);
        transform.position = Vector2.MoveTowards(transform.position,
        chooseAlien.transform.position, moveSpeed * Time.deltaTime);
        minn = 10;
        // else Destroy(gameObject);
    }

    private Alien FindAlien()
    {
        for (int i = aliens.Length - 1; i >= 0; i--)
        {
            if (aliens[i].GetHealth() < minn)
            {
                minn = aliens[i].GetHealth();
                chooseAlien = aliens[i];
            }
        }
        return chooseAlien;
    }
}
