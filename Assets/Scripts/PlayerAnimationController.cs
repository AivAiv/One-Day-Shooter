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
        animator.SetFloat("MoveX", x);
        animator.SetFloat("MoveY", y);
        animator.SetInteger("Facing", lastFacing);
    }

    public void Walk(float x, float y)
    {
        animator.SetBool("IsMoving", true);
        animator.SetBool("IsShooting", false);
        
        if (y > 0 && x < y) {
            lastFacing = 1;
        }
        else if (x > 0 && x > y) {
            lastFacing = 2;
        }
        else if (y < 0 && x < y) {
            lastFacing = 3;
        }
        else if (x < 0 && x > y)
        {
            lastFacing = 4;
        }

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
