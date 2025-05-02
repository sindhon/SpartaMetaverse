using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpLoader : MonoBehaviour
{
    public GameObject popUp;
    public GameObject chat;
    public GameObject changedChat;

    public bool IsChanged = false;

    public bool IsPopUp = true;

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
            if (IsPopUp)
            {
                popUp.SetActive(true);
                if (IsChanged)
                {
                    chat.SetActive(false);
                    changedChat.SetActive(true);
                }
            }
            else
            {
                SceneManager.LoadScene(2); // FlappyGame æ¿¿∏∑Œ ¿Ãµø
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsPopUp)
        {
            if (other.CompareTag("Player"))
            {
                popUp.SetActive(false);
            }
        }
    }
}
