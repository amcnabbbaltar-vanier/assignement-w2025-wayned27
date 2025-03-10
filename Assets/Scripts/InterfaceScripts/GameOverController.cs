using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
