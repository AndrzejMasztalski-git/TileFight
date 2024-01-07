using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeInterface : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    public GameManager gameManager;
    public SkillsMenu skillMenu;
    public Button returnButton;
    public TMPro.TextMeshProUGUI loseText;
    public TMPro.TextMeshProUGUI winText;
    public void ResumeButtonClicked()
    {
        gameManager.escapeMenu.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void SkillsButtonClicked()
    {
        skillMenu.skillsMenu.GetComponent<Canvas>().enabled = true;
        gameManager.escapeMenu.GetComponent<Canvas>().enabled = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
