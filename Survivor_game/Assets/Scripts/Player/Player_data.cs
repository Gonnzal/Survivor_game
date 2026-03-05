using System.Collections.Generic;
using UnityEngine;

public class Player_data : MonoBehaviour
{
    public float XP;
    public float money;
    public float level;
    public List<GameObject> weapons = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddXP(float amount)
    {
        XP += amount;
        if (XP >= 100 * level)
        {
            level++;
        }
    }

    public void AddMoney(float amount)
    {
        money += amount;
    }

    public void activateWeapon(int weapon)
    {
        weapons[weapon].SetActive(true);
    }
}
