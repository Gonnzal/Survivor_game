using System.Collections;
using UnityEngine;

public class RangedAI : AI
{
    public float projectileSpeed = 8f;
    public float bulletLifeTime = 3f;
    [SerializeField] GameObject projectilePrefab;

    new void Start() { base.Start(); }

    new void Update()
    {
        base.Update();
        if (distance <= range && canAttack)
            Attack();
    }

    void Attack()
    {
        GameObject bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Pasar los datos directamente al proyectil
        Proyectile p = bullet.GetComponent<Proyectile>();
        p.damage = damage;
        p.speed = projectileSpeed;
        p.lifeTime = bulletLifeTime;

        canAttack = false;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
