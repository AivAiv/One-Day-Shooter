using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;

    public void Start()
    {
        player.OnIdle += Idle;
        player.OnWalk += Walk;
        player.OnDeath += Die;
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        animator.SetBool("IsDeadTrig", true);
        animator.SetBool("IsShooting", false);
    }

    public void Idle(float x, float y)
    {
        animator.SetBool("IsMoving", false);
        animator.SetBool("IsShooting", false);
        animator.SetFloat("MoveX", x);
        animator.SetFloat("MoveY", y);
    }

    public void Walk(float x, float y)
    {
        animator.SetBool("IsMoving", true);
        animator.SetBool("IsShooting", false);
        animator.SetFloat("MoveX", x);
        animator.SetFloat("MoveY", y);
    }

    public void Shoot(float x, float y)
    {
        animator.SetBool("IsShooting", true);
        animator.SetFloat("MoveX", x);
        animator.SetFloat("MoveY", y);
    }
}
