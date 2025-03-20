using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float repeatTimer = 1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score = 0;
    private bool isGameOver = true;
    public GameObject mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TossATarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(repeatTimer);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScoreText(int AddScore)
    {
        score += AddScore;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficultyScaler)
    {
        mainMenu.SetActive(false);
        isGameOver = false;
        repeatTimer /= difficultyScaler;
        StartCoroutine(TossATarget());
        scoreText.text = "Score: " + score;
    }
}