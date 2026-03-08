using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerOld : MonoBehaviour
{
    [Header("Puntos de Spawn")]
    public List<Transform> spawnPoints = new();

    [Header("Prefabs de Enemigos")]
    public List<GameObject> enemyPrefabs = new();

    [Header("Configuración")]
    public int maxActiveEnemies = 20;
    public float spawnInterval = 1.5f;

    private List<GameObject> pool = new();
    private int activeCount = 0;
    private int lastSpawnIndex = -1;
    private bool isSpawning = false;

    void Awake()
    {
        // Prewarm: instanciar 5 copias de cada prefab desactivadas
        foreach (var prefab in enemyPrefabs)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.GetComponent<PooledEnemy>().sourcePrefab = prefab;
                obj.SetActive(false);
                pool.Add(obj);
            }
        }
    }

    public void OnWaveStart(int wave)
    {
        isSpawning = true;
        StartCoroutine(SpawnLoop());
    }

    public void OnWaveEnd()
    {
        isSpawning = false;
    }

    private IEnumerator SpawnLoop()
    {
        while (isSpawning)
        {
            if (activeCount < maxActiveEnemies)
                SpawnEnemy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Punto de spawn: aleatorio sin repetir el anterior
        int index;
        do { index = Random.Range(0, spawnPoints.Count); }
        while (index == lastSpawnIndex && spawnPoints.Count > 1);
        lastSpawnIndex = index;

        // Buscar un enemigo inactivo en el pool
        GameObject enemy = pool.Find(e => !e.activeInHierarchy);

        if (enemy == null)
        {
            // Pool vacio: crear uno nuevo
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            enemy = Instantiate(prefab, transform);
            enemy.GetComponent<PooledEnemy>().sourcePrefab = prefab;
            pool.Add(enemy);
        }

        enemy.transform.position = spawnPoints[index].position;
        enemy.SetActive(true);
        activeCount++;
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        activeCount--;
    }
}