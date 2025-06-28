using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;
    [SerializeField] private ProjectileShooter shooter;
    [SerializeField] private SpriteRenderer _playerRenderer;
    private float lastX = 0f;
    private float lastY = -1f;


    public void Start()
    {
        _playerRenderer = player.gameObject.GetComponent<SpriteRenderer>();
        shooter = player.gameObject.GetComponent<ProjectileShooter>();
        player.OnIdle += Idle;
        player.OnWalk += Walk;
        player.OnDeath += Die;
        shooter.OnShoot += Shoot;
    }

    public void Die()
    {
        animator.SetTrigger("IsDead");
    }

    public void Idle(float x, float y)
    {
        animator.ResetTrigger("IdleFront");
        animator.ResetTrigger("IdleBack");
        animator.ResetTrigger("IdleSide");

        if (Mathf.Abs(lastX) > Mathf.Abs(lastY))
        {
            _playerRenderer.flipX = lastX < 0;
            animator.SetTrigger("IdleSide");
        }
        else if (lastY > 0)
        {
            animator.SetTrigger("IdleBack");
        }
        else
        {
            animator.SetTrigger("IdleFront");
        }
    }

    public void Walk(float x, float y)
    {
        if (x != 0 || y != 0)
        {
            lastX = x;
            lastY = y;
        }

        animator.ResetTrigger("WalkFront");
        animator.ResetTrigger("WalkBack");
        animator.ResetTrigger("WalkSide");

        if (x != 0)
        {
            _playerRenderer.flipX = x < 0;
            animator.SetTrigger("WalkSide");
        }

        if (y > 0)
        {
            animator.SetTrigger("WalkBack");
        }
        else if (y < 0)
        {
            animator.SetTrigger("WalkFront");
        }
    }

    public void Shoot(float x, float y)
    {
        if (x != 0 || y != 0)
        {
            lastX = x;
            lastY = y;
        }

        animator.ResetTrigger("ShootFront");
        animator.ResetTrigger("ShootBack");
        animator.ResetTrigger("ShootSide");

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            _playerRenderer.flipX = x < 0;
            animator.SetTrigger("ShootSide");
        }
        else if (y > 0)
        {
            animator.SetTrigger("ShootBack");
        }
        else if (y < 0)
        {
            animator.SetTrigger("ShootFront");
        }
    }

    void OnDestroy()
    {
        if (player || shooter) {
            player.OnIdle -= Idle;
            player.OnWalk -= Walk;
            player.OnDeath -= Die;
            shooter.OnShoot -= Shoot;
        }
    }
}
