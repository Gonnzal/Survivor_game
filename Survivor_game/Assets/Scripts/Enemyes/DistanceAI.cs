using UnityEngine;

public class DistanceAI : EnemyAI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        vidaMax = 10;
        velocidad = 5;
        danio = 5f;
        distanciaJugador = 5;
        base.Start();
        rb2D.mass = 1f;
    }
}
