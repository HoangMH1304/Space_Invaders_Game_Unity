using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public void OnDeadAnimation(GameObject other)
    {
        Animator animator = other.GetComponent<Animator>();
        animator.SetBool("IsDead", true);
    }

    public void OnTargetAnimation(GameObject other)
    {
        Animator animator = other.GetComponent<Animator>();
        animator.SetBool("IsTarget", true);
    }

    public void ExitTargetAnimation(GameObject other)
    {
        Animator animator = other.GetComponent<Animator>();
        animator.SetBool("IsTarget", false);
    }

}
