using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerState
{
    public float coolDownMax1;
    public float coolDownMax2;
    public float coolDownMax3;
    public float coolDownDashMax;
    public float maxDashTime;
    public float defaultSpeed;
    public float dashSpeed;
}
public class playerController : MonoBehaviour
{
    [SerializeField]private float maxHealth;

    public PlayerState[] state;
    protected PlayerState currentState;

    [SerializeField] float health;
    float coolDown1;
    float coolDown2;
    float coolDown3;
    float coolDownDash;
    bool dashing;
    float dashTime;
    float speed;

    public List<GameObject> poolPunch = new List<GameObject>();
    public List<GameObject> poolAxe = new List<GameObject>();
    public List<GameObject> poolScream = new List<GameObject>();
    private int punchSize = 2;
    private int axeSize = 2;
    private int screamSize = 2;
    public GameObject punch;
    public GameObject axe;
    public GameObject scream;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float detectionRadius = 20f;
    private Transform objetivoReal;
    [SerializeField] Rounds canvas;

    private float searchTimer = 0f;
    private float searchRate = 0.2f; // actualiza 5 veces por segundo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = state[0];
        coolDown1 = currentState.coolDownMax1;
        coolDown2 = currentState.coolDownMax2;
        coolDown3 = currentState.coolDownMax3;
        dashing = false;
        dashTime = 0;
        speed = currentState.defaultSpeed;
        health = maxHealth;
        AddPunchToPool(punchSize);
        AddAxeToPool(axeSize);
        AddScreamToPool(screamSize);
    }

    // Update is called once per frame
    void Update()
    {
        searchTimer -= Time.deltaTime;
        if (searchTimer <= 0f)
        {
            FindEnemy();
            searchTimer = searchRate;
        }
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

    public void ReceiveDamage(int damage)
    {
        health -= damage;

        if (health <= maxHealth * 0.75f && health > maxHealth * 0.5f)
        {
            currentState = state[1];
        }
        else if (health <= maxHealth * 0.5f && health > maxHealth * 0.25f)
        {
            currentState = state[2];
        }
        else if (health <= maxHealth * 0.25f)
        {
            currentState = state[3];
        }
    }

    void FindEnemy()
    {
        // Solo busca dentro del radio, usando el motor de fisica
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            this.transform.position,
            detectionRadius,
            enemyLayer
        );

        if (enemies.Length == 0)
        {
            objetivoReal = null;
            return;
        }

        Transform masCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float distancia = Vector2.Distance(this.transform.position, enemy.transform.position);
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                masCercano = enemy.transform;
            }
        }

        objetivoReal = masCercano;
    }

    void Ataque1()
    {
        if (objetivoReal == null) return;

        if (coolDown1 <= 0)
        {
            GameObject dispPunch = ActivarPunch();
            Punch punchScript = dispPunch.GetComponent<Punch>();
            punchScript.DispararPunch(this.transform.position, objetivoReal.position);
            coolDown1 = currentState.coolDownMax1;
        }
        else
        {    
            coolDown1 -= Time.deltaTime;
        }
    }

    void Ataque2()
    {
        if (objetivoReal == null) return;

        if (coolDown2 <= 0)
        {
            GameObject dispAxe = ActivarAxe();
            Axe axeScript = dispAxe.GetComponent<Axe>();
            axeScript.DispararAxe(this.transform.position, objetivoReal.position);
            coolDown2 = currentState.coolDownMax2;
        }
        else
        {    
            coolDown2 -= Time.deltaTime;
        }
    }

    void Ataque3()
    {
        if (objetivoReal == null) return;

        if (coolDown3 <= 0)
        {
            GameObject dispScream = ActivarScream();
            Scream screamScript = dispScream.GetComponent<Scream>();
            screamScript.DispararScream(this.transform.position);
            coolDown3 = currentState.coolDownMax3;
        }
        else
        {    
            coolDown3 -= Time.deltaTime;
        }
    }

    void AddPunchToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject punchP = Instantiate(punch);
            punchP.gameObject.SetActive(false);
            poolPunch.Add(punch);
            punchP.transform.parent = this.transform;
        }
    }

    void AddAxeToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject axeP = Instantiate(axe);
            axeP.gameObject.SetActive(false);
            poolAxe.Add(axeP);
            axeP.transform.parent = this.transform;
        }
    }

    void AddScreamToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject screamP = Instantiate(scream);
            screamP.gameObject.SetActive(false);
            poolScream.Add(screamP);
            screamP.transform.parent = this.transform;
        }
    }

    public GameObject ActivarPunch()
    {
        for (int i = 0; i < poolPunch.Count; i++)
        {
            if (!poolPunch[i].activeSelf)
            {
                poolPunch[i].SetActive(true);
                return poolPunch[i];
            }
        }
        AddPunchToPool(1);
        poolPunch[poolPunch.Count - 1].SetActive(true);
        return poolPunch[poolPunch.Count - 1];
    }

    public GameObject ActivarAxe()
    {
        for (int i = 0; i < poolAxe.Count; i++)
        {
            if (!poolAxe[i].activeSelf)
            {
                poolAxe[i].SetActive(true);
                return poolAxe[i];
            }
        }
        AddAxeToPool(1);
        poolAxe[poolAxe.Count - 1].SetActive(true);
        return poolAxe[poolAxe.Count - 1];
    }

    public GameObject ActivarScream()
    {
        for (int i = 0; i < poolScream.Count; i++)
        {
            if (!poolScream[i].activeSelf)
            {
                poolScream[i].SetActive(true);
                return poolScream[i];
            }
        }
        AddScreamToPool(1);
        poolScream[poolScream.Count - 1].SetActive(true);
        return poolScream[poolScream.Count - 1];
    }

    void Dash()
    {
        if(coolDownDash <= 0)
        {
            speed = currentState.dashSpeed;
            coolDownDash = currentState.coolDownDashMax;
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
            if(dashTime >= currentState.maxDashTime)
            {
                dashing = false;
                speed = currentState.defaultSpeed;
                dashTime = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            canvas.DeathCanvas();
        }
    }

    public void Heal(int heal)
    {
        health+= heal;
    }
}
