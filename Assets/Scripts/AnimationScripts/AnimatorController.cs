using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;
    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
    }
    public void LateUpdate()
    {
        UpdateAnimator();
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        if (animator == null || characterMovement == null)
        {
            return;
        }
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsFalling", !characterMovement.IsGrounded);
    }
}
