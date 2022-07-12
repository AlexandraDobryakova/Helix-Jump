using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEvents : MonoBehaviour
{
    public Button sound;
    public Button unSound;

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            sound.gameObject.SetActive(true);
            unSound.gameObject.SetActive(false);
        }
        else
        {
            GameManager.mute = true;
            sound.gameObject.SetActive(false);
            unSound.gameObject.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
