using UnityEngine;

public class drops : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(TryGetComponent<playerController>(out playerController player ))
        {
            player.Heal(heal);
        }
        Destroy(this);
    }
}
