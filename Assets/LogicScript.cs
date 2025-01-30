using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public Text highScoreText; 
    private int highScore;
    void Start()
    {
        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = "Highscore: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore); // Save new high score
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}