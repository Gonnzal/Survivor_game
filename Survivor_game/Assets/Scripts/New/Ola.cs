using UnityEngine;

public class Ola : MonoBehaviour
{
    private int damage = 99999;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sweeper collided with: " + other.gameObject.name);
        if (other.gameObject.TryGetComponent<AmeleAI>(out AmeleAI enemy))
        {
            Debug.Log("Sweeper hit an enemy");
            enemy.ReciveDanio(damage);
        }
        else if(other.gameObject.TryGetComponent<DistanceAI>(out DistanceAI enemy2))
        {
            enemy2.ReciveDanio(damage);
        }
        DesactiveOla();
    }


    void DesactiveOla()
    {
        this.gameObject.SetActive(false);
    }
}
