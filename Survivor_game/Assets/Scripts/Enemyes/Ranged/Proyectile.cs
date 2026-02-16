using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Proyectile : MonoBehaviour
{
    [SerializeField] float speed;
    public float damage;
    float speedY;
    float speedX;
    [SerializeField] bool collision = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<RangedAI>().damage;
        speed = GameObject.FindGameObjectWithTag("Enemy").GetComponent<RangedAI>().proyectileSpeed;
        speedX = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed;
        speedY = Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speedX * Time.deltaTime, transform.position.y + speedY * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        collision = true;
        TryGetComponent<healthManager>(out healthManager health);
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }   
    }
}
