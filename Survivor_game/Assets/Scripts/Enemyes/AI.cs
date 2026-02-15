using Unity.VisualScripting;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float cooldown;
    [SerializeField] Transform player;
    bool canAttack = true;
    float distanceX;
    float distanceY;
    float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceX = player.transform.position.x - transform.position.x;
        distanceY = player.transform.position.y - transform.position.y;
        distance = Mathf.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

        if(distance > range)
        {
            GetCloser();
        }
        else if (distance <= range && canAttack)
        {
            //Attack();
        }
    }

    void GetCloser()
    {
        if(distanceX > 0)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else if (distanceX < 0)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (distanceY > 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (distanceY < 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
