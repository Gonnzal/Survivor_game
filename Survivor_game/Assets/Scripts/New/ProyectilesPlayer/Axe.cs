using UnityEngine;

public class Axe : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float lifeTime = 3f;
    private float speed = 5f;

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
}
