using UnityEngine;

/// <summary>
/// It destroys the current game object after a certain amount of time
/// </summary>
public class DelayedDestructor : MonoBehaviour
{
    [SerializeField] private float delay = 4f;

    private void Start() => Destroy(gameObject, delay);
}