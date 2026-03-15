using UnityEngine;
using System.Collections.Generic;

public class BoosAI : EnemyAI
{
    public List<GameObject> poolBalas = new List<GameObject>();
    private int balasSize = 2;
    public GameObject balaPrefab;
    private float shootCooldown = 3f;
    private float shootTimer = 0f;
    float distanceX;

    protected override void Start()
    {
        vidaMax = 100;
        velocidad = 5;
        danio = 5;
        distanciaJugador = 20f;

        targets.Add(playerController.instance.transform);
        vida = vidaMax;
        if (animator == null) { animator = GetComponent<Animator>(); }
        if (rb2D == null) { rb2D = GetComponent<Rigidbody2D>(); }

        rb2D.mass = 1f;
        AddBalaToPool(balasSize);
    }

    protected override void Update()
    {
        base.Update();
        EnemigoDisapara();
        distanceX = transform.position.x - targets[0].transform.position.x;
        if(distanceX > 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(distanceX < 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void EnemigoDisapara()
    {
        shootTimer -= Time.deltaTime;

        Vector2 diferencia = (Vector2)objetivoReal.position - rb2D.position;
        if (shootTimer <= 0f && diferencia.magnitude <= distanciaJugador)
        {
            objetivoReal = targets[targets.Count - 1];
            animator.SetTrigger("Shoot");
            GameObject dispBala = ActivarBala();
            BalaEnemy balaScript = dispBala.GetComponent<BalaEnemy>();
            balaScript.Disparar(this.transform.position, objetivoReal.position);
            shootTimer = shootCooldown;
        }
        else
        {
            objetivoReal = targets[0];
        }
    }

    void AddBalaToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bala = Instantiate(balaPrefab);
            bala.gameObject.SetActive(false);
            poolBalas.Add(bala);
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