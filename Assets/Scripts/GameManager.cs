using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighscoreText;
    public Button restartBtn, quitBtn;

    private static string HIGH_SCORE = "Highscore";

    private void Awake()
    {
        gameOverPanel.SetActive(false);

        GetHighscore();
    }

    public void IncreaseScore(int v)
    {
        score += v;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, score);
            highScoreText.text = "Best: " + score;
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighscoreText.text = "Best: " + highScore.ToString();

        gameOverPanel.SetActive(true);
        //Debug.Log("Bomb hitted");
    }

    public void RestartGame()
    {
        GetHighscore();

        // Reset the score and the game over panel
        gameOverPanel.SetActive(false);
        score = 0;

        // Find gameobjects to destroy
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
            Destroy(g);

        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Das Spiel wurde beendet!");
        Application.Quit();
    }

    private void GetHighscore()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE);
        highScoreText.text = "Best: " + highScore;
    }
}
