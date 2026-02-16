using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleAI : AI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (distance <= range && canAttack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if(canAttack)
        {
            playerHealth.TakeDamage(damage);
        }
        canAttack = false;
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
