using UnityEngine;

/// <summary>
/// Destroy the game objects when it hits something
/// </summary>
public class DestroyOnContact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _) => Destroy(gameObject);
}