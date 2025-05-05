using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    Home,
    Lobby,
    SelectGame,
    Game,
    GameOver
}

public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    LobbyUI lobbyUI;
    SelectUI selectUI;
    GameUI gameUI;
    GameOverUI gameOverUI;

    private UIState currentState;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);
        lobbyUI = GetComponentInChildren<LobbyUI>(true);
        lobbyUI?.Init(this);
        selectUI = GetComponentInChildren<SelectUI>(true);
        selectUI?.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI?.Init(this);

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            ChangeState(UIState.Home);
        }
        else if (SceneManager.GetActiveScene().name == "GameSelectScene")
        {
            ChangeState(UIState.SelectGame);
        }
        else
            ChangeState(UIState.Game);
        
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Lobby);
    }

    public void UpdateScore(int score)
    {
        gameUI?.SetUI(score);
    }

    public void UpdateBestScore(int bestscore)
    {
        selectUI?.SetUI(bestscore);
    }

    public void StartMiniGame()
    {
        SceneManager.LoadScene("FlappyGameScene");
    }

    public void SetGameOverUI()
    {
        gameOverUI?.SetUI(gameManager.CurrentScore, gameManager.BestScore);
        ChangeState(UIState.GameOver);
    }

    public void ReturnSelectScene()
    {
        SceneManager.LoadScene("GameSelectScene");
    }

    public void RestartMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        lobbyUI?.SetActive(currentState);
        selectUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }
}
