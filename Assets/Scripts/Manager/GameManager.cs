using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player { get; private set; }

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
        uiManager.SetPlayGame();
    }
}
