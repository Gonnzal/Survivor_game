using UnityEngine;

public class healthManager : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void RegenHelth(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
