using Unity.Burst.Intrinsics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static Tower instance;

    [SerializeField] private float maxHealth;
    private float health;
    Rounds rondas;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        rondas = GameObject.Find("canvasManager").GetComponent<Rounds>();
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
            rondas.DeathCanvas();
        }
    }

    public virtual void ReceiveDamage(int damage)
    {
        health -= damage;
    }
}
