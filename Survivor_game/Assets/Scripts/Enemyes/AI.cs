using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AI : MonoBehaviour
{
    [SerializeField] public float range;
    [SerializeField] float speed;
    [SerializeField] public float damage;
    [SerializeField] public float cooldown;
    [SerializeField] Transform player;
    public bool canAttack = true;
    public float distanceX;
    public float distanceY;
    public float distance;
    public healthManager playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<healthManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        distanceX = player.transform.position.x - transform.position.x;
        distanceY = player.transform.position.y - transform.position.y;
        distance = Mathf.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

        if(distance > range)
        {
            GetCloser();
        }
    }

    void GetCloser()
    {
        float angle = Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if(distanceX == 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else if(distanceX > -0.3f && distanceX < 0.3f)
        {
            transform.position = new Vector2(player.transform.position.x, transform.position.y);
        }
        else if(distanceX > 0.3f)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else if (distanceX < -0.3f)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if(distanceY == 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else if(distanceY > -0.3f && distanceY < 0.3f)
        {
            transform.position = new Vector2(transform.position.x, player.transform.position.y);
        }
        else if (distanceY > 0.3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (distanceY < -0.3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
