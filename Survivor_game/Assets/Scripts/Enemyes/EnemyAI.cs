using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] objetivos;
    public Transform objetivoReal;
    public float vida;
    protected float vidaMax;
    protected float velocidad;
    public float distanciaJugador;
    protected float danio;
    private Animator animator;
    protected Rigidbody2D rb2D;
    int objective;

    protected virtual void Start()
    {
        objective = Random.Range(0, 2);
        danio = 1;
        vida = vidaMax;
        if (animator == null) { animator = GetComponent<Animator>(); }
        if (rb2D == null) { rb2D = GetComponent<Rigidbody2D>(); }
    }

    protected virtual void Update()
    {
        objetivoReal = objetivos[objective];
        Moverse();
    }

    void Moverse()
    {
        Vector2 diferencia = (Vector2)objetivoReal.position - rb2D.position;
        float distancia = diferencia.magnitude;

        if (distancia > distanciaJugador)
        {
            rb2D.linearVelocity = diferencia.normalized * velocidad;
        }
        else
        {
            rb2D.linearVelocity = Vector2.zero;
        }
    }

    public void ReciveDanio(int danio)
    {
        vida -= danio;
        if(vida <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        if (vida <= 0)
        {
            danio = 0;
            velocidad = 0;
            animator.SetTrigger("Dead");
        }
    }

    void DeadAnim()
    {
        this.gameObject.SetActive(false);
    }
}