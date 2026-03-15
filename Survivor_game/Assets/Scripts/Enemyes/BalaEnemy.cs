using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BalaEnemy : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float lifeTime = 3f;
    private float speed = 5f;
    [SerializeField] int damage;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
       StartCoroutine(FlipBala());
    }

    void Update()
    {
        LifeTime();
        if(rb2D.linearVelocityX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(rb2D.linearVelocityX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
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

    public void Disparar(Vector2 origen, Vector2 destino)
    {
        gameObject.SetActive(true);

        transform.position = origen;
        lifeTime = 3f;

        Vector2 direccion = (destino - origen).normalized;

        if (direccion.x < 0f)
        transform.localScale = new Vector2(-1, 1);

        rb2D.linearVelocity = direccion * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<playerController>(out playerController obj))
        {
            obj.TakeDamage(damage);
        }
        if(other.gameObject.TryGetComponent<Tower>(out Tower obj2))
        {
            obj2.ReceiveDamage(damage);
        }
    }

    IEnumerator FlipBala()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return null;
        }
        if(rb2D.linearVelocityX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(rb2D.linearVelocityX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}