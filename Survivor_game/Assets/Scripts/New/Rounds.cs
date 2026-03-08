using UnityEngine;
using TMPro;

public class Rounds : MonoBehaviour
{
    [SerializeField] int roundCount;
    [SerializeField] TMP_Text timeCounter;
    [SerializeField] float roundDuration;
    [SerializeField] CanvasGroup gameCanvas;
    [SerializeField] CanvasGroup mainMenuCanvas;
    [SerializeField] CanvasGroup creditsCanvas;
    [SerializeField] CanvasGroup deathCanvas;
    [SerializeField] CanvasGroup finishCanvas;
    [SerializeField] CanvasGroup canvasBetweenRounds;
    [SerializeField] EnemyAI enemyHealth;
    int currentRound;
    float roundProgress;
    int minuteCount;
    int second2Count;
    int second1Count;
    public bool roundFinished;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRound = 0;
        timeCounter.text = minuteCount.ToString() + ":" + second1Count.ToString() + second2Count.ToString();
        roundFinished = false;
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
        roundFinished = true;
        canvasBetweenRounds.interactable = true;
        canvasBetweenRounds.alpha = 1;
        gameCanvas.interactable = false;
        gameCanvas.alpha = 0;
        Time.timeScale = 0;
        enemyHealth.ReciveDanio(9999);
        //hacer desaparecer a todos los enemigos
    }
    
    void BossRound()
    {
        
    }

    public void StartRound()
    {
        Time.timeScale = 1;
        currentRound++;
        if(currentRound == roundCount)
        {
            BossRound();
        }
    }

    public void MainMenu()
    {
        mainMenuCanvas.interactable = true;
        mainMenuCanvas.alpha = 1;
        canvasBetweenRounds.interactable = false;
        canvasBetweenRounds.alpha = 0;
        gameCanvas.interactable = false;
        gameCanvas.alpha = 0;
        finishCanvas.interactable = false;
        finishCanvas.alpha = 0;
        deathCanvas.interactable = false;
        deathCanvas.alpha = 0;
        creditsCanvas.interactable = false;
        creditsCanvas.alpha = 0;
    }

    public void Credits()
    {
        mainMenuCanvas.interactable = false;
        mainMenuCanvas.alpha = 0;
        canvasBetweenRounds.interactable = false;
        canvasBetweenRounds.alpha = 0;
        gameCanvas.interactable = false;
        gameCanvas.alpha = 0;
        finishCanvas.interactable = false;
        finishCanvas.alpha = 0;
        deathCanvas.interactable = false;
        deathCanvas.alpha = 0;
        creditsCanvas.interactable = true;
        creditsCanvas.alpha = 1;
    }

    public void Game()
    {
        mainMenuCanvas.interactable = false;
        mainMenuCanvas.alpha = 0;
        canvasBetweenRounds.interactable = false;
        canvasBetweenRounds.alpha = 0;
        gameCanvas.interactable = true;
        gameCanvas.alpha = 1;
        finishCanvas.interactable = false;
        finishCanvas.alpha = 0;
        deathCanvas.interactable = false;
        deathCanvas.alpha = 0;
        creditsCanvas.interactable = false;
        creditsCanvas.alpha = 0;
    }
    public void DeathCanvas()
    {
        mainMenuCanvas.interactable = false;
        mainMenuCanvas.alpha = 0;
        canvasBetweenRounds.interactable = false;
        canvasBetweenRounds.alpha = 0;
        gameCanvas.interactable = false;
        gameCanvas.alpha = 0;
        finishCanvas.interactable = false;
        finishCanvas.alpha = 0;
        deathCanvas.interactable = true;
        deathCanvas.alpha = 1;
        creditsCanvas.interactable = false;
        creditsCanvas.alpha = 0;
    }
    public void FinishCanvas()
    {
        mainMenuCanvas.interactable = false;
        mainMenuCanvas.alpha = 0;
        canvasBetweenRounds.interactable = false;
        canvasBetweenRounds.alpha = 0;
        gameCanvas.interactable = false;
        gameCanvas.alpha = 0;
        finishCanvas.interactable = true;
        finishCanvas.alpha = 1;
        deathCanvas.interactable = false;
        deathCanvas.alpha = 0;
        creditsCanvas.interactable = false;
        creditsCanvas.alpha = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
