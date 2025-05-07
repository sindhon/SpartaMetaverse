using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentScore = 0;
    public int CurrentScore {  get { return currentScore; } }

    private int bestScore = 0;
    public int BestScore { get { return bestScore; } }

    private UIManager uiManager;
    public static bool isFirstLoading = true;

    private void Awake()
    {
        Instance = this;

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScore();

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (!isFirstLoading)
            {
                StartGame();
            }
            else
            {
                isFirstLoading = false;
            }
        }
    }


    public void StartGame()
    {
        uiManager.SetPlayGame();
        UpdateBestScore();
    }

    public void UpdateBestScore()
    {   
        uiManager.UpdateBestScore(bestScore);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);

        uiManager.SetGameOverUI();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > bestScore)
            bestScore = currentScore;
        uiManager.UpdateScore(currentScore);
    }
}
