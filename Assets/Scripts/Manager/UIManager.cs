using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    Home,
    Lobby,
    Game,
    GameOver
}
public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    LobbyUI lobbyUI;
    GameUI gameUI;
    GameOverUI gameOverUI;

    private UIState currentState;

    GameManager gameManager;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        lobbyUI = GetComponentInChildren<LobbyUI>(true);
        lobbyUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Lobby);
    }

    public void SetPlayMiniGame()
    {
        ChangeState(UIState.Home);
    }

    public void SetGameOverUI()
    {
        gameOverUI.SetUI(gameManager.CurrentScore, gameManager.BestScore);
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
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }
}
