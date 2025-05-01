using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player { get; private set; }

    private UIManager uiManager;

    private void Awake()
    {
        Instance = this;

        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        uiManager.SetPlayGame();
    }
}
