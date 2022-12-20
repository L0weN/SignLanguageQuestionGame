using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoSingleton<AnimationController>
{
    [SerializeField] private Animator animator;

    public void TrueButtonClicked()
    {
        animator.SetTrigger("True");
    }
    
    public void FalseButtonClicked()
    {
        animator.SetTrigger("False");
    }
}
