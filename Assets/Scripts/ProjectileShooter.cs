using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab; // Assign in Inspector
    [SerializeField] private float projectileSpeed = 30f;
    
    private Camera _mainCamera;
    
    
    private void Start()
    {
        _mainCamera = Camera.main;
        GetComponent<PlayerController>().InputActions.Standard.Shoot.performed += _ => FireProjectile();
    }

    private void FireProjectile()
    {
        var mouseWorldPos = _mainCamera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
                _mainCamera.transform.position.y - transform.position.y)
        );

        var fireDirection = (mouseWorldPos - transform.position).normalized;
        var projectile = Instantiate(
            projectilePrefab,
            transform.position,
            Quaternion.LookRotation(fireDirection)
        );

        if (!projectile.TryGetComponent<Rigidbody2D>(out var rb)) return;
        rb.velocity = fireDirection * projectileSpeed;
    }
}