using UnityEngine;
using TMPro;

public class Rounds : MonoBehaviour
{
    [SerializeField] int roundCount;
    [SerializeField] TMP_Text timeCounter;
    [SerializeField] float roundDuration;
    int currentRound;
    float roundProgress;
    int minuteCount;
    int second2Count;
    int second1Count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRound = 0;
        timeCounter.text = minuteCount.ToString() + ":" + second1Count.ToString() + second2Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        roundProgress += Time.deltaTime;
        if(roundProgress >= 1)
        {
            second2Count++;
            roundProgress = 0;
            if(second2Count == 10)
            {
                second1Count++;
                second2Count = 0;
            }
            if(second1Count == 6)
            {
                minuteCount++;
                second1Count = 0;
                second2Count = 0;
            }
            timeCounter.text = minuteCount.ToString() + ":" + second1Count.ToString() + second2Count.ToString();
        }
        if(minuteCount == roundDuration)
        {
            FinishRound();
        }
    }

    void FinishRound()
    {
        /*
        aquí hay que: 
        1. hacer desaparecer a todos los enemigos
        2. hacer que aparezca la tienda o menú entre rondas
        */
    }
    
    void BossRound()
    {
        
    }
}
