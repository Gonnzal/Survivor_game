using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct RoundState
{
    public int maxEnemies;    // limite global en escena
    public float spawnRate;   // cada cuanto spawna algun spawner
}

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance; 

    public RoundState[] rounds;
    public Spawner[] spawners;

    private RoundState currentRound;
    private int roundIndex = 0;
    private float spawnTimer = 0f;

    // Propiedad global — cuenta enemigos activos en todos los spawners
    public int TotalActiveEnemies
    {
        get
        {
            int total = 0;
            foreach (Spawner s in spawners)
                total += s.ActiveEnemies;
            return total;
        }
    }

    void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (rounds == null || rounds.Length == 0)
        {
            Debug.LogError("SpawnManager: No hay rondas configuradas.", this);
            return;
        }
        currentRound = rounds[0];
    }

    void Update()
    {
        if (spawners == null || spawners.Length == 0) return;

        // Solo spawnea si no se ha alcanzado el limite global
        if (TotalActiveEnemies >= currentRound.maxEnemies) return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            // Elegir un spawner aleatorio
            Spawner spawnerAleatorio = spawners[Random.Range(0, spawners.Length)];
            spawnerAleatorio.SpawnEnemy();
            spawnTimer = currentRound.spawnRate;
        }
    }

    public void NextRound()
    {
        if (roundIndex + 1 < rounds.Length)
        {
            roundIndex++;
            currentRound = rounds[roundIndex];
            Debug.Log($"Ronda {roundIndex + 1} iniciada.");
        }
    }
}