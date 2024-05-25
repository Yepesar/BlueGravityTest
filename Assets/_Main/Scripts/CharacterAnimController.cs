using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayIdle()
    {
        animator.SetBool("Walking", false);
    }

    public void PlayWalk()
    {
        animator.SetBool("Walking", true);
    }
}
