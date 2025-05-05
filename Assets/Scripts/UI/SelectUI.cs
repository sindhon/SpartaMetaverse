using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button playButton;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        playButton.onClick.AddListener(OnClickPlayButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.SelectGame;
    }

    public void OnClickPlayButton()
    {
        uiManager.StartMiniGame();
    }

    public void SetUI(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }
}
