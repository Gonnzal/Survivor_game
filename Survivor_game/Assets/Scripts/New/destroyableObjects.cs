using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class destroyableObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> drop = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        Instantiate(drop[Random.Range(0, drop.Count+1)]);
        Destroy(gameObject);
    }
}
