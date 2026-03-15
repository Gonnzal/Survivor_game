using UnityEngine;

public class AmeleAI : EnemyAI
{
    [SerializeField] float cooldownMax;
    float cooldown;

    public AudioClip[] atack;
    public AudioClip[] move;

    float soundCooldown;

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

    protected override void Update()
    {
        base.Update();
        EmitirSonido();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Bite");
        SoundManager.instance.PlaySFX(atack[Random.Range(0, atack.Length - 1)]);
        if (collision.gameObject.TryGetComponent<playerController>(out playerController obj))
        {
            obj.ReceiveDamage(danio);
        }
    }

    void EmitirSonido()
    {
        soundCooldown += Time.deltaTime;

        if (soundCooldown > 7)
        {
            SoundManager.instance.PlaySFX(move[Random.Range(0, move.Length - 1)]);
            soundCooldown = 0;
        }
    }
}
