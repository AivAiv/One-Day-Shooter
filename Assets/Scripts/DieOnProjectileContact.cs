using System;
using UnityEngine;

public class DieOnProjectileContact : MonoBehaviour
{
    [SerializeField] private UserInfo userInfo;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Projectile")) return;
        userInfo.kills += 1;
        Destroy(gameObject);
    }
}
