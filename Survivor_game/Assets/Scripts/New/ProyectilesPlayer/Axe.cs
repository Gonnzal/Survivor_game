using UnityEngine;

public class Axe : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float lifeTime = 3f;
    private float speed = 5f;
    public int damage;

    public AudioClip[] axe;

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
        }
    }

    public void DispararAxe(Vector2 origen, Vector2 destino)
    {
        gameObject.SetActive(true);

        transform.position = origen;
        lifeTime = 3f;

        if (rb2D == null) { rb2D = GetComponent<Rigidbody2D>(); }
        Vector2 direccion = (destino - origen).normalized;
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
