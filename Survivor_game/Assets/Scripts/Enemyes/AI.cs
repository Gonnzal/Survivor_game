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
    [SerializeField] float distanceDifference;
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
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
