using System.Collections;
using UnityEngine;

public class MeleAI : AI
{
    new void Start() { base.Start(); }

    new void Update()
    {
        base.Update();
        if (distance <= range && canAttack)
            Attack();
    }

    void Attack()
    {
        playerHealth.TakeDamage(damage);
        canAttack = false;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
