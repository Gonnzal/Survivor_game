using UnityEngine;

public class PooledEnemy : MonoBehaviour
{
    [HideInInspector] public GameObject sourcePrefab;

    private SpawnManager spawnManager;

    void Awake()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
    }

    // Llama esto desde el script del enemigo
    public void ReturnToPool()
    {
        // spawnManager.ReturnToPool(gameObject);
    }
}

// Ejemplo de uso en tu script Enemy:
//
// void Die()
// {
//     GetComponent<PooledEnemy>().ReturnToPool();
// }
