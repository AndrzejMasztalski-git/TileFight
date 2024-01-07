using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas settingsCanvas;

    private void Start()
    {
        mainCanvas.GetComponent<Canvas>().enabled = true;
        settingsCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void SettingsButtonClicked()
    {
        mainCanvas.GetComponent<Canvas>().enabled = false;
        settingsCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void BackButtonClicked()
    {
        mainCanvas.GetComponent<Canvas>().enabled = true;
        settingsCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void NewGameButtonClicked()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    
}

