using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayerProyectile : MonoBehaviour
{
    public float speed;
    public Vector3 target;
    public float damage;
    public int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<healthManager>().TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }
}
