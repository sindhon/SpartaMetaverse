using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player { get; private set; }

    private int currentScore = 0;
    public int CurrentScore {  get { return currentScore; } }
    private int bestScore = 0;
    public int BestScore { get { return bestScore; } }

    private UIManager uiManager;
    public static bool isFirstLoading = true;

    private void Awake()
    {
        Instance = this;

        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
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


    public void StartGame()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            uiManager.SetPlayGame();
            return;
        }

        uiManager.SetPlayMiniGame();
    }

    public void GameOver()
    {
        uiManager.SetGameOverUI();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > bestScore)
            bestScore = currentScore;
    }
}
