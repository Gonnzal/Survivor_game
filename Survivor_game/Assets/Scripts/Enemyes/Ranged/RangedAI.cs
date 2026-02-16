using System.Collections;
using UnityEngine;

public class RangedAI : AI
{
    [SerializeField] public float proyectileSpeed;
    [SerializeField] GameObject proyectile;
    [SerializeField] public float bulletLifeTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg));
        if(distance <= range*2 /3 && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        Instantiate(proyectile, transform.position, transform.rotation);
        canAttack = false;
        StartCoroutine(AttackCoodown());
    }


    IEnumerator AttackCoodown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
