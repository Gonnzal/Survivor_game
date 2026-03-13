using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Rounds : MonoBehaviour
{
    [SerializeField] int roundCount;
    [SerializeField] TMP_Text timeCounter;
    [SerializeField] float roundDuration;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas canvasBetweenRounds;
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas death;
    [SerializeField] Canvas win;
    [SerializeField] Canvas credits;
    [SerializeField] GameObject wave;
    int currentRound;
    float roundProgress;
    int minuteCount;
    int second2Count;
    int second1Count;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRound = 0;
        MainMenu();
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
        gameCanvas.enabled = false;
        canvasBetweenRounds.enabled = true;
        wave.SetActive(true);
        minuteCount = 0;
        second2Count = 0;
        second1Count = 0;
    }
    
    void BossRound()
    {
        
    }

    public void MainMenu()
    {
        mainMenu.enabled = true;
        gameCanvas.enabled = false;
        canvasBetweenRounds.enabled = false;
        credits.enabled = false;
        win.enabled = false;
        death.enabled = false;
    }

    public void Credits()
    {
        mainMenu.enabled = false;
        credits.enabled = true;
    }

    public void StartRound()
    {
        Time.timeScale = 1;
        gameCanvas.enabled = true;
        mainMenu.enabled = false;
        canvasBetweenRounds.enabled = false;
        currentRound++;
        if(currentRound == roundCount)
        {
            BossRound();
        }
    }
    public void DeathCanvas()
    {
        gameCanvas.enabled = false;
        death.enabled = true;
    }
    public void FinishCanvas()
    {
        gameCanvas.enabled = false;
        win.enabled = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Testeo");
    }
}

