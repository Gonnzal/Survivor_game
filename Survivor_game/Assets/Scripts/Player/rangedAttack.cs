using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class rangedAttack : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float coolDown;
    [SerializeField] float proyectileSpeed;
    [SerializeField] GameObject proyectile;
    [SerializeField] float damage;
    float distanceToTarget;
    float tempDistance;
    bool canShoot = true;
    Vector3 target;
    GameObject[] proyectiles = new GameObject[] {};
    int[] poolIndex = new int[] {};
    [SerializeField] int proyectileCount;
    [SerializeField] 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < proyectileCount+1; i++)
        {
            GameObject temp = Instantiate(proyectile, transform.position, transform.rotation);
            temp.GetComponent<PlayerProyectile>().speed = proyectileSpeed;
            temp.GetComponent<PlayerProyectile>().damage = damage;
            System.Array.Resize(ref proyectiles, proyectiles.Length + 1);
            proyectiles[proyectiles.Length - 1] = temp;
            temp.SetActive(false);
            System.Array.Resize(ref poolIndex, poolIndex.Length +1);
            poolIndex[poolIndex.Length-1] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
            /*
            foreach (GameObject obj in )
            {
                MeasureDistance(obj);
                if(tempDistance < distanceToTarget)
                {
                    SelectTarget(obj);
                }
            }
            */

            for (int i = 0; i<poolIndex.Length; i++)
            {
                if(poolIndex[i] == 0)
                {
                    proyectiles[i].SetActive(true);
                    proyectiles[i].GetComponent<PlayerProyectile>().target = target;
                }
            }
        }
    }

    void MeasureDistance(GameObject obj)
    {
        float distanceX = this.transform.position.x - obj.transform.position.x;
        float distanceY = this.transform.position.y - obj.transform.position.y;
        float distanceZ = this.transform.position.z - obj.transform.position.z;
        tempDistance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ);
    }

    void SelectTarget(GameObject obj)
    {
        target = obj.transform.position;
    }
/*
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDown);
    }
    */
}
