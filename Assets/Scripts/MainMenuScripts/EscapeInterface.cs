using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeInterface : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    public GameManager gameManager;
    public SkillsMenu skillMenu;
    
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
}
