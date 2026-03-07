using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public Transform[] objetivos;
    private Transform objetivoReal;
    public float vida;
    protected float vidaMax;
    protected float velocidad;
    protected float distanciaJugador;
    protected float danio;
    private Animator animator;
    protected Rigidbody2D rb2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        objetivoReal = objetivos[Random.Range(0,2)];
        danio = 1;
        vida = vidaMax;
        if (animator == null) { animator = GetComponent<Animator>(); }
        if (rb2D == null) { rb2D = GetComponent<Rigidbody2D>(); }
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }

    void Moverse()
    {
        // Calculamos la direccion del enemigo hacia el objetivo
        Vector2 diferencia = (Vector2)objetivoReal.position - rb2D.position;
        float distancia = diferencia.magnitude;

        if (distancia > distanciaJugador)
        {
            Vector2 direccion = diferencia.normalized;
            // Movemos al enemigo en esa direccion
            rb2D.linearVelocity = direccion * velocidad;
        }
        else
        { 
            rb2D.linearVelocity = Vector2.zero;
        }
    }

    public void ReciveDanio(int danio)
    {
        vida -= danio;
    }

    void Muerte()
    {
        if (vida <= 0)
        {
            velocidad = 0;
            animator.SetTrigger("Dead");
        }
    }


    void DeadAnim()
    {
        this.gameObject.SetActive(false);
    }
}
