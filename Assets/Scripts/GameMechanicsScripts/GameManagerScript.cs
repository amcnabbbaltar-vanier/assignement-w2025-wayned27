using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int savedScore = 0;
    public float gameTime = 0f;
    private bool isPlaying = true;
    public TMP_Text timerText;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreAndTime();
    }
    void Update()
    {
        if (isPlaying)
        {
            gameTime += Time.deltaTime;
            UpdateScoreAndTime();
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += ReloadScene;
        }
    }

    // SCORE and TIMER METHODS
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreAndTime();
    }
    public void SaveScoreProgress()
    {
        savedScore = score;
    }
    public void ResetScoreIfDie(bool isScene1)
    {
        if (isScene1)
        {
            score = 0;
            savedScore = 0;
        }
        else
        {
            score = savedScore;
        }
        UpdateScoreAndTime();
    }
    public void PlayAgain()
    {
        score = 0;
        savedScore = 0;
        gameTime = 0f;
        isPlaying = true;
        UpdateScoreAndTime();
    }
    public void StopTimerIfGameOver()
    {
        isPlaying = false;
    }

    // UI METHODS
    void UpdateScoreAndTime()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (timerText != null) timerText.text = "Time: " + Mathf.FloorToInt(gameTime).ToString();
    }
    void ContinueScoreAndTime()
    {
        timerText = GameObject.Find("TimeText")?.GetComponent<TMP_Text>();
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();
        UpdateScoreAndTime();
    }

    // SCENE MANAGEMENT METHODS
    private void ReloadScene(Scene sc, LoadSceneMode lsMode)
    {
        ContinueScoreAndTime();
        if (sc.buildIndex == 1)
        {
            ResetScoreIfDie(true);
        }
        else if (sc.buildIndex > 1)
        {
            SaveScoreProgress();
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
