using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void UpdateResult(Collider2D other)
    {
        if(other.tag == "Alien")
        {
            score += 10;
            scoreText.text = score.ToString();
        }
            
    }
}
