using UnityEngine;

public class BossAI : EnemyAI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        vidaMax = 100;
        velocidad = 1;
        danio = 5;
        distanciaJugador = 5;
        base.Start();
        rb2D.mass = 2f;
    }
}
