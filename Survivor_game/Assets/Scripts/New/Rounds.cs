using UnityEngine;
using TMPro;

public class Rounds : MonoBehaviour
{
    [SerializeField] int roundCOunt;
    [SerializeField] TMP_Text timeCOunter;
    int currentRound;
    float roundProgress;
    float roundDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRound = 0;
        NextRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextRound()
    {
        currentRound++;

    }
}
