using UnityEngine;
using System.Collections.Generic;

public class DistanceAI : EnemyAI
{
    public List<BalaEnemy> poolBalas = new List<BalaEnemy>();
    public BalaEnemy balaPrefab;
    private float shootCooldown = 3f;
    private float shootTimer = 0f;

    protected override void Start()
    {
        vidaMax = 10;
        velocidad = 5;
        danio = 5f;
        distanciaJugador = 5f;
        base.Start();
        rb2D.mass = 1f;

        // Instanciar el pool
        for (int i = 0; i < 5; i++)
        {
            BalaEnemy instancia = Instantiate(balaPrefab);
            instancia.gameObject.SetActive(false);
            poolBalas.Add(instancia);
        }
    }

    protected override void Update()
    {
        base.Update();
        Shoot();
    }

    void Shoot()
    {
        shootTimer -= Time.deltaTime;

        Vector2 diferencia = (Vector2)objetivoReal.position - rb2D.position;
        float distancia = diferencia.magnitude;

        if (distancia <= distanciaJugador && shootTimer <= 0f)
        {
            Ataque();
            shootTimer = shootCooldown;
        }
    }

    void Ataque()
    {
        BalaEnemy balaDisponible = poolBalas.Find(b => !b.gameObject.activeSelf);

        if (balaDisponible != null)
        {
            balaDisponible.Disparar(
                this.transform.position,        // origen: posicion del enemigo
                objetivoReal.position      // destino: posicion actual del jugador (no lo sigue)
            );
        }
    }
}