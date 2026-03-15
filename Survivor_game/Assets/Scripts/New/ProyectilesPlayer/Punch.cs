using UnityEngine;

public class Punch : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float lifeTime = 0.5f;
    private float speed = 30f;
    public int damage = 5;

    public AudioClip[] punch;

    public AudioClip[] danioAmele;
    public AudioClip[] danioBoss;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        LifeTime();
    }

    void LifeTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            rb2D.linearVelocity = Vector2.zero;
            gameObject.SetActive(false);
            lifeTime = 0.5f;
        }
    }

    public void DispararPunch(Vector2 origen, Vector2 destino)
    {
        gameObject.SetActive(true);
        SoundManager.instance.PlaySFX(punch[Random.Range(0, punch.Length - 1)]);

        transform.position = origen;

        if (rb2D == null) { rb2D = GetComponent<Rigidbody2D>(); }
        Vector2 direccion = (destino - origen).normalized;

        if (direccion.x < 0f)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);

        rb2D.linearVelocity = direccion * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<AmeleAI>(out AmeleAI enemy))
        {
            SoundManager.instance.PlaySFX(danioAmele[Random.Range(0, danioAmele.Length - 1)]);
            enemy.ReciveDanio(damage);
        }
        else if (other.gameObject.TryGetComponent<DistanceAI>(out DistanceAI enemy2))
        {
            enemy2.ReciveDanio(damage);
        }
        else if (other.gameObject.TryGetComponent<BoosAI>(out BoosAI enemy3))
        {
            SoundManager.instance.PlaySFX(danioBoss[Random.Range(0, danioBoss.Length - 1)]);
            enemy3.ReciveDanio(damage);
        }
    }
}
