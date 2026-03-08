using UnityEngine;

public class Scream : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
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

    public void DispararScream()
    {
        gameObject.SetActive(true);
        // animator.SetTrigger("Scream");
    }

    void AnimEnd()
    {
        this.gameObject.SetActive(false);
    }
}
