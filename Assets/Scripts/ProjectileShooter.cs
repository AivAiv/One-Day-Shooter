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
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(_mainCamera.transform.position.z); // Distance from camera to plane
        var mouseWorldPos = _mainCamera.ScreenToWorldPoint(mouseScreenPos);

        var fireDirection = (mouseWorldPos - transform.position).normalized;
        var angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.Euler(0, 0, angle);
        var projectile = Instantiate(
            projectilePrefab,
            transform.position,
            rotation
        );

        if (!projectile.TryGetComponent<Rigidbody2D>(out var rb)) return;
        rb.velocity = fireDirection * projectileSpeed;
    }
}