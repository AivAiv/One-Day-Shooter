using UnityEngine;

/// <summary>
/// Simple mono behaviour that expose a method to spawn stuff
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    public void Spawn() => Instantiate(prefabToSpawn, transform.position, transform.rotation, null);
}