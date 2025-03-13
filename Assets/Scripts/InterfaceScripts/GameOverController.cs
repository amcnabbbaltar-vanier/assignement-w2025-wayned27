using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text finalTimeText;
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StopTimerIfGameOver();
            finalScoreText.text = "Final Score: " + GameManager.Instance.score;
            finalTimeText.text = "Game Time: " + Mathf.FloorToInt(GameManager.Instance.gameTime).ToString();
        }
    }
    public void RestartGame()
    {
        GameManager.Instance.PlayAgain();
        SceneManager.LoadScene(0);
    }
}
