using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;

    [SerializeField] private int lastFacing = 3;

    public void Start()
    {
        player.OnIdle += Idle;
        player.OnWalk += Walk;
        player.OnDeath += Die;
    }

    public void Die()
    {
        animator.SetTrigger("IsDead");
        animator.SetBool("IsShooting", false);
        animator.SetBool("IsMoving", false);
    }

    public void Idle(float x, float y)
    {
        animator.SetBool("IsMoving", false);
        animator.SetBool("IsShooting", false);
        animator.SetInteger("Facing", lastFacing);
    }

    public void Walk(float x, float y)
    {
        animator.SetBool("IsMoving", true);
        animator.SetBool("IsShooting", false);
        
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            // destra o sinistra
            lastFacing = x > 0 ? 0 : 0;
        }
        else if (Mathf.Abs(y) > 0)
        {
            // su o giù
            lastFacing = y > 0 ? 1 : 3;
        }
    }

    public void Shoot(float x, float y)
    {
        animator.SetBool("IsShooting", true);
        animator.SetFloat("MoveX", x);
        animator.SetFloat("MoveY", y);
    }
}
