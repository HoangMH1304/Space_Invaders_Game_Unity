using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimation : MonoBehaviour
{

    // public void OnEnableAnimation()
    // {
    //     Animator animator = GameObject.Find("player1").GetComponent<Animator>();
    //     animator.enabled = !animator.enabled;
    // }

    public void OnDeadAnimation(GameObject other)
    {
        Animator animator = other.GetComponent<Animator>();
        animator.SetBool("IsDead", true);
    }
}
