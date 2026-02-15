using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float dashTime;
    [SerializeField] float dashCooldown;
    bool canDash = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        speed = speed * 2;
        yield return new WaitForSeconds(dashTime);
        speed = speed / 2;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
