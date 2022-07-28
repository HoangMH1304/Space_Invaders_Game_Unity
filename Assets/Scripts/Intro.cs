using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private Animator animator;
    public void BlurText1()
    {
        animator = GameObject.Find("Space Invader").GetComponent<Animator>();
        animator.enabled = !animator.enabled;
    }

    public void BlurText2()
    {
        animator = GameObject.Find("ChoosePlayer").GetComponent<Animator>();
        animator.enabled = !animator.enabled;
    }

    public void SpaceShipAnimation()
    {
        animator = GameObject.Find("SpaceShip").GetComponent<Animator>();
        animator.enabled = !animator.enabled;
    }

    public void PlayButton()
    {
        animator = GameObject.Find("Play").GetComponent<Animator>();
        animator.enabled = !animator.enabled;
    }
}
