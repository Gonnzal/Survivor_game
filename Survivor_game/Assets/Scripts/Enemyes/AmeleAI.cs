using UnityEngine;

public class AmeleAI : EnemyAI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        vidaMax = 10;
        velocidad = 5;
        danio = 5f;
        distanciaJugador = 1f;
        base.Start();
        rb2D.mass = 0.01f;
    }

}
