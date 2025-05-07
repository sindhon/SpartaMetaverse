using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : BaseUI
{
    public static UnityEvent<bool> OnOpenPortalButtonClicked = new UnityEvent<bool>();

    [SerializeField] private Button openPortalButton;
    [SerializeField] private Button enterPortalButton;

    [SerializeField] private GameObject chat;
    [SerializeField] private ParticleSystem portalParticle;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        openPortalButton.onClick.AddListener(OnClickOpenPortalButton);
        enterPortalButton.onClick.AddListener(OnClickEnterPortalButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.Lobby;
    }

    public void OnClickOpenPortalButton()
    {
        OnOpenPortalButtonClicked.Invoke(true);

        chat.SetActive(false);

        if (portalParticle != null)
        {
            portalParticle.Play();
        }
    }

    public void OnClickEnterPortalButton()
    {
        uiManager.ReturnSelectScene();
    }
}
