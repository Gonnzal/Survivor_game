using UnityEngine;

public class Scream : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    public int damage;

    public AudioClip[] grito;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    public void DispararScream(Vector2 origen)
    {
        SoundManager.instance.PlaySFX(grito[Random.Range(0, grito.Length - 1)]);
        this.transform.position = origen;
        gameObject.SetActive(true);
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
        else if(other.gameObject.TryGetComponent<BoosAI>(out BoosAI enemy3))
        {
            enemy3.ReciveDanio(damage);
        }
    }
}
