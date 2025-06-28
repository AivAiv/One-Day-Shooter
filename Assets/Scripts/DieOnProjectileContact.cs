using System;
using UnityEngine;

public class DieOnProjectileContact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Projectile")) return;
        SessionData.Kills++;
        Destroy(gameObject);
    }
}
