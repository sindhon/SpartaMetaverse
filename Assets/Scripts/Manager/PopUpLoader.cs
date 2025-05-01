using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpLoader : MonoBehaviour
{
    public GameObject popUp;
    public GameObject chat;
    public GameObject changedChat;

    public bool IsChanged = false;

    private void OnEnable()
    {
        LobbyUI.OnOpenPortalButtonClicked.AddListener(HandleOpenPortalButtonClick);
    }

    private void OnDisable()
    {
        LobbyUI.OnOpenPortalButtonClicked.RemoveListener(HandleOpenPortalButtonClick);
    }

    private void HandleOpenPortalButtonClick(bool value)
    {
        IsChanged = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(true);
            if (IsChanged)
            {
                chat.SetActive(false);
                changedChat.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }
}
