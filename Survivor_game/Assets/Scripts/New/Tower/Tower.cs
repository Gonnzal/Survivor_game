using Unity.Burst.Intrinsics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static Tower instance;

    [SerializeField] private float maxHealth;
    private float health;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        LoseCondition();
    }

    void LoseCondition()
    {
        if (health <= 0)
        {
            // menu de derrota
        }
    }

    public virtual void ReceiveDamage(int damage)
    {
        // Debug.Log(health);
        health -= damage;
        // Debug.Log(health);
    }
}
