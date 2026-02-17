using UnityEngine;

public class Healing_object : MonoBehaviour
{
    [SerializeField] int heal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<healthManager>().RegenHelth(heal);
            Destroy(gameObject);
        }
    }
}
