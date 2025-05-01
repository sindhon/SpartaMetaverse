using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : BaseUI
{
    [SerializeField] private Button openPortalButton;
    [SerializeField] private Button enterPortalButton;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        openPortalButton.onClick.AddListener(OnClickOpenPortalButton);
        enterPortalButton.onClick.AddListener(OnClickEnterPortalButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.Lobby;
    }

    public void OnClickOpenPortalButton()
    {
        Debug.Log("open");
    }

    public void OnClickEnterPortalButton()
    {
        Debug.Log("enter");
    }
}
