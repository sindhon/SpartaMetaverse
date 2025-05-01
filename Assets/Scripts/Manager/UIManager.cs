using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        lobbyUI = GetComponentInChildren<LobbyUI>(true);
        lobbyUI.Init(this);

        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        lobbyUI.SetActive(currentState);
    }
}
