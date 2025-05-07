using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpLoader : MonoBehaviour
{
    public GameObject popUp;
    public GameObject chat;
    public GameObject changedChat;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(true);
            if (changedChat != null && uiManager.IsPortalOpen)
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
            if (popUp != null)
            {
                popUp.SetActive(false);
            }
        }
    }
}
