using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DistanceAI : EnemyAI
{
    public List<GameObject> poolBalas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            // Instantiate(Bala);
            // Bala.setactive(false);
            // poolBalas.Add(Bala);
        }
        vidaMax = 10;
        velocidad = 5;
        danio = 5f;
        distanciaJugador = 5;
        base.Start();
        rb2D.mass = 1f;
    }

    void Ataque()
    {
        // activar proyectil
    }
}
