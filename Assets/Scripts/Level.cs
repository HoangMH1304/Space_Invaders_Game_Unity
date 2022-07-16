using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public int level = 1;
    public Text levelText;
    public void SetLevel()
    {
        levelText.text =  level.ToString();
    }
}
