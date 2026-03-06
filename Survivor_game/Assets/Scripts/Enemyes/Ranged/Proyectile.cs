using System.Collections;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    // Asignados por RangedAI al instanciar
    [HideInInspector] public float damage;
    [HideInInspector] public float speed;
    [HideInInspector] public float lifeTime;

    private Vector2 velocity;

    void Start()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        healthManager health = other.gameObject.GetComponent<healthManager>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
