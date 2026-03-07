using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]float coolDownMax1;
    [SerializeField]float coolDownMax2;
    [SerializeField]float coolDownMax3;
    [SerializeField] float coolDownDashMax;
    [SerializeField] float maxDashTime;
    [SerializeField] float defaultSpeed;
    [SerializeField] float dashSpeed;
    float coolDown1;
    float coolDown2;
    float coolDown3;
    float coolDownDash;
    bool dashing;
    float dashTime;
    float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coolDown1 = coolDownMax1;
        coolDown2 = coolDownMax2;
        coolDown3 = coolDownMax3;
        dashing = false;
        dashTime = 0;
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Ataque1();
        Ataque2();
        Ataque3();
        DashCheck();
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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

    }

    void Ataque1()
    {
        if(coolDown1 <= 0)
        {
            //ataque
        }
        else
        {    
            coolDown1 -= Time.deltaTime;
        }
    }

    void Ataque2()
    {
        if(coolDown2 <= 0)
        {
            //ataque
        }
        else
        {    
            coolDown2 -= Time.deltaTime;
        }
    }

    void Ataque3()
    {
       if(coolDown3 <= 0)
        {
            //ataque
        }
        else
        {    
            coolDown3 -= Time.deltaTime;
        }
    }
    void Dash()
    {
        if(coolDownDash <= 0)
        {
            speed = dashSpeed;
            coolDownDash = coolDownDashMax;
            dashing = true;
        }
    }

    void DashCheck()
    {
        if(coolDownDash > 0)
        {
            coolDownDash -= Time.deltaTime;
        }

        if(dashing)
        {
            Debug.Log("Dash");
            dashTime += Time.deltaTime;
            if(dashTime >= maxDashTime)
            {
                dashing = false;
                speed = defaultSpeed;
                dashTime = 0;
            }
        }
    }
}
