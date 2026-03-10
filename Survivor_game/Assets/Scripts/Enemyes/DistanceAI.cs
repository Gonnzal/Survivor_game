using UnityEngine;
using System.Collections.Generic;

public class DistanceAI : EnemyAI
{
    public List<GameObject> poolBalas = new List<GameObject>();
    private int balasSize = 2;
    public GameObject balaPrefab;
    private float shootCooldown = 3f;
    private float shootTimer = 0f;

    protected override void Start()
    {
        vidaMax = 10;
        velocidad = 5;
        danio = 5;
        distanciaJugador = 5f;
        base.Start();
        rb2D.mass = 1f;
        AddBalaToPool(balasSize);
    }

    protected override void Update()
    {
        base.Update();
        EnemigoDisapara();
    }

    void EnemigoDisapara()
    {
        shootTimer -= Time.deltaTime;

        Vector2 diferencia = (Vector2)objetivoReal.position - rb2D.position;
        if (shootTimer <= 0f && diferencia.magnitude <= distanciaJugador)
        {
            GameObject dispBala = ActivarBala();
            BalaEnemy balaScript = dispBala.GetComponent<BalaEnemy>();
            balaScript.Disparar(this.transform.position, objetivoReal.position);
            shootTimer = shootCooldown;
        }
    }

    void AddBalaToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bala = Instantiate(balaPrefab);
            bala.gameObject.SetActive(false);
            poolBalas.Add(bala);
            bala.transform.parent = this.transform;
        }
    }

    public GameObject ActivarBala()
    {
        for (int i = 0; i < poolBalas.Count; i++)
        {
            if (!poolBalas[i].activeSelf)
            {
                poolBalas[i].SetActive(true);
                return poolBalas[i];
            }
        }
        AddBalaToPool(1);
        poolBalas[poolBalas.Count - 1].SetActive(true);
        return poolBalas[poolBalas.Count - 1];
    }
}