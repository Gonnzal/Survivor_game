using UnityEngine;

public class AI : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth = 100f;
    public float speed = 3f;
    public float damage = 10f;
    public float range = 2f;
    public float cooldown = 1f;

    [Header("Estado")]
    public float health;
    public bool canAttack = true;

    protected Transform player;
    public healthManager playerHealth;

    public float distanceX;
    public float distanceY;
    public float distance;

    private PooledEnemy pooledEnemy;

    public void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<healthManager>();
        pooledEnemy = GetComponent<PooledEnemy>();
    }

    public void Update()
    {
        distanceX = player.position.x - transform.position.x;
        distanceY = player.position.y - transform.position.y;
        distance = Vector2.Distance(transform.position, player.position);

        if (distance > range)
            MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = new Vector2(distanceX, distanceY).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        float angle = Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        health = maxHealth; // reset para cuando vuelva del pool
        canAttack = true;
        pooledEnemy.ReturnToPool();
    }
}
