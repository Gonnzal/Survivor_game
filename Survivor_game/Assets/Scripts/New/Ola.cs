using UnityEngine;

public class Ola : MonoBehaviour
{
    private int damage = 99999;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sweeper collided with: " + other.gameObject.name);
        if (other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemy))
        {
            Debug.Log("Sweeper hit an enemy");
            enemy.ReciveDanio(damage);
        }
    }


    void DesactiveOla()
    {
        this.gameObject.SetActive(false);
    }
}
