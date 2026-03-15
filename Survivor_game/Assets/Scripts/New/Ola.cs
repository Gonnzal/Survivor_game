using UnityEngine;

public class Ola : MonoBehaviour
{
    private int damage = 99999;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<AmeleAI>(out AmeleAI enemy))
        {
            enemy.ReciveDanio(damage);
        }
        else if(other.gameObject.TryGetComponent<DistanceAI>(out DistanceAI enemy2))
        {
            enemy2.ReciveDanio(damage);
        }
        else if(other.gameObject.TryGetComponent<BoosAI>(out BoosAI enemy3))
        {
            enemy3.ReciveDanio(damage);
        }
    }


    void DesactiveOla()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(false);
    }
}
