using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class ConstantSpawner : MonoBehaviour
{
    private Spawner _spawner;
    [SerializeField, Min(0f)] private float loopTime = 1f;
    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(loopTime);
            _spawner.Spawn();
        }
    }
}
