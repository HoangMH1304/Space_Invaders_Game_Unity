using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNormalAlien : MonoBehaviour
{
    public void KickNormalAlien()
    {
        Alien[] aliens = null;
        aliens = FindObjectsOfType<Alien>();
        for (int i = aliens.Length - 1; i >= 0; i--)
        {
            if (aliens[i] != null)
            {
                aliens[i].DestroyNormalAlien();
            }
        }
    }
}
