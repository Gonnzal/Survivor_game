// Rounds.cs
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
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject boss;
    [SerializeField] Canvas mecanicas;

    int currentRound;
    float roundProgress;
    int minuteCount;
    int second2Count;
    int second1Count;

    public AudioClip menusMusic;
    public AudioClip round1;
    public AudioClip round2;
    public AudioClip round3;
    public AudioClip round4;
    public AudioClip round5;
    public AudioClip round5Loop;

    public AudioClip hambiente;
    playerController vidaPlayer;
    Tower vidaMuro;
    [SerializeField] TMP_Text vidaplayer;
    [SerializeField] TMP_Text vidamuro;
    bool bossDead;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        SoundManager.instance.PlayMusic(menusMusic);
        currentRound = 0;
        vidaPlayer = GameObject.Find("Player").GetComponent<playerController>();
        vidaMuro = GameObject.Find("PUERTA MADERA_0").GetComponent<Tower>();
        vidaplayer.text = "Vida del jugador: " + vidaPlayer.health + " / 100";
        vidamuro.text = "Vida de la puerta: " + vidaMuro.health + " / 100";
        mainMenu.enabled = true;
        gameCanvas.enabled = false;
        canvasBetweenRounds.enabled = false;
        credits.enabled = false;
        win.enabled = false;
        death.enabled = false;
        mecanicas.enabled = false;
        bossDead = true;
    }

    void Update()
    {
        roundProgress += Time.deltaTime;
        if (roundProgress >= 1)
        {
            second2Count++;
            roundProgress = 0;
            if (second2Count == 10) { second1Count++; second2Count = 0; }
            if (second1Count == 6) { minuteCount++; second1Count = 0; second2Count = 0; }
            timeCounter.text = minuteCount + ":" + second1Count + second2Count;
            vidaplayer.text = "Vida del jugador: " + vidaPlayer.health + " / 100";
            vidamuro.text = "Vida de la puerta: " + vidaMuro.health + " / 200";
        }

        // Solo avanza automaticamente si NO es el round final (Round 5 es indefinido)
        if (minuteCount >= roundDuration && currentRound != roundCount && currentRound < roundCount)
        {
            FinishRound();
        }
    }

    // Devuelve el clip de musica segun el round
    AudioClip MusicForRound(int round)
    {
        return round switch
        {
            1 => round1,
            2 => round2,
            3 => round3,
            4 => round4,
            5 => round5,
            _ => menusMusic
        };
    }

    void PlayRoundMusic(int round)
    {
        if (round == roundCount) // Round 5
        {
            SoundManager.instance.PlayMusicThenLoop(round5, round5Loop);
        }
        else
        {
            SoundManager.instance.PlayMusic(MusicForRound(round), loop: false);
        }
    }

    void FinishRound()
    {
        SoundManager.instance.StopMusic();
        // El ambiente lo dejamos sonar

        gameCanvas.enabled = false;
        canvasBetweenRounds.enabled = true;
        wave.SetActive(true);
        minuteCount = 0;
        second2Count = 0;
        second1Count = 0;
    }

    void BossRound()
    {
        Instantiate(boss);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Testeo");
        SoundManager.instance.PlayMusic(menusMusic);
        SoundManager.instance.StopHambient();
        minuteCount = 0;
        second2Count = 0;
        second1Count = 0;
        Time.timeScale = 0;
    }

    public void Credits()
    {
        mainMenu.enabled = false;
        credits.enabled = true;
    }

    public void StartRound()
    {
        Time.timeScale = 1;
        currentRound++;

        PlayRoundMusic(currentRound);

        // Arranca el ambiente solo al empezar el juego
        if (currentRound == 1)
            SoundManager.instance.PlayHambient(hambiente);

        timeCounter.text = minuteCount + ":" + second1Count + second2Count;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        gameCanvas.enabled = true;
        mainMenu.enabled = false;
        canvasBetweenRounds.enabled = false;

        if (currentRound == roundCount)
            BossRound();
    }

    public void DeathCanvas()
    {
        SoundManager.instance.StopMusic();
        SoundManager.instance.StopHambient();
        bossDead = false;
        Time.timeScale = 0;
        gameCanvas.enabled = false;
        death.enabled = true;
    }

    public void FinishCanvas()
    {
        SoundManager.instance.StopMusic();
        SoundManager.instance.StopHambient();
        gameCanvas.enabled = false;
        win.enabled = true;
        wave.SetActive(true);
    }

    public void Upgrade()
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.interactable = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Mecanicas()
    {
        mainMenu.enabled = false;
        mecanicas.enabled = true;
    }
}