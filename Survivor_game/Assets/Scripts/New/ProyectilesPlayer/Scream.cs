using UnityEngine;

public class Scream : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    public int damage;
    //private float lifeTime = 3f;
    //private float speed = 5f;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Puede que no sean necesarios
    //void Update()
    //{
    //    LifeTime();
    //}

    //void LifeTime()
    //{
    //    lifeTime -= Time.deltaTime;
    //    if (lifeTime <= 0f)
    //    {
    //        rb2D.linearVelocity = Vector2.zero;
    //        gameObject.SetActive(false);
    //    }
    //}

    public void DispararScream(Vector2 origen)
    {
        this.transform.position = origen;
        gameObject.SetActive(true);
        // animator.SetTrigger("Scream");
    }

    void AnimEnd()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<AmeleAI>(out AmeleAI enemy))
        {
            enemy.ReciveDanio(damage);
        }
        else if(other.gameObject.TryGetComponent<DistanceAI>(out DistanceAI enemy2))
        {
            enemy2.ReciveDanio(damage);
        }
    }
}
