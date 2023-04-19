using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameLogic : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public AudioSource deathSFX;

    public void Start()
    {
        loadScore();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int score)
    {
        if (gameOverScreen.activeSelf == false)
        {
            playerScore += score;
            scoreText.text = playerScore.ToString();
            dingSFX.Play();
        }
        if (playerScore > highScore) { highScoreText.text = "Highscore: " + playerScore.ToString(); }
    }

    public void saveScore()
    {
        if (playerScore > highScore) { PlayerPrefs.SetInt("storedScore", playerScore); }
    }

    public void loadScore()
    {
        highScore = PlayerPrefs.GetInt("storedScore");
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        saveScore();
        deathSFX.Play();
    }

    public void enterTitle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
