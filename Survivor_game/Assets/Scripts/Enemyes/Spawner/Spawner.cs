using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour 
{
    public GameObject[] enemysPrefab;
    private List<GameObject> enemiesPool = new List<GameObject>();
    private int poolSize = 5;

    public int ActiveEnemies => enemiesPool.FindAll(e => e.activeSelf).Count;

    void Start()
    {
        AddToPool(poolSize);
    }

    void AddToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemysPrefab[Random.Range(0, enemysPrefab.Length)]);
            enemy.SetActive(false);
            enemy.transform.parent = this.transform;
            enemiesPool.Add(enemy);
        }
    }

    public void SpawnEnemy()
    {
        // Buscar uno inactivo en el pool
        GameObject enemy = enemiesPool.Find(e => !e.activeSelf);

        // Si no hay, expandir el pool
        if (enemy == null)
        {
            AddToPool(1);
            enemy = enemiesPool[enemiesPool.Count - 1];
        }

        enemy.transform.position = this.transform.position;
        enemy.SetActive(true);
    }
}