using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text highScoreText;

    public GameObject gameOverPanel;
    public Text scoreTextPanel;
    public Text highScoreTextPanel;

    public AudioClip[] sliceSouds;
    public AudioClip bombSound;
    private AudioSource audioSound;
    private void Awake()
    {
        audioSound = GetComponent<AudioSource>();
        highScoreText.text = "Best: " + GetHighScore();
        gameOverPanel.SetActive(false);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        if (score > GetHighScore())
        {
            highScoreText.text = "Best: " + score;
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
    public void OnBombHit() {
        scoreTextPanel.text = "Score: " + score;
        highScoreTextPanel.text = "High Score: " + GetHighScore();
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void PlayRandomSound()
    {
        AudioClip aud = sliceSouds[Random.Range(0, sliceSouds.Length)];
        audioSound.PlayOneShot(aud);
    }
    public void PlayBombSound()
    {
        audioSound.PlayOneShot(bombSound);
    }
}
