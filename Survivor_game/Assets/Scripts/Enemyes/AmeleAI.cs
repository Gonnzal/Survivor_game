using UnityEngine;

public class AmeleAI : EnemyAI
{
    [SerializeField] float cooldownMax;
    float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        vidaMax = 10;
        velocidad = 5;
        danio = 5;
        distanciaJugador = 1f;
        base.Start();
        rb2D.mass = 0.01f;
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<playerController>(out playerController obj))
        {
            obj.ReceiveDamage(danio);
        }
    }

    void OTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<playerController>(out playerController obj))
        {
            if (cooldown >= cooldownMax)
            {
                obj.ReceiveDamage(danio);
                cooldown = 0;
            }
            cooldown += Time.deltaTime;
        }
    }

}
