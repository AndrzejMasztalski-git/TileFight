using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas escapeMenu;
    public SkillsMenu skillMenu;
    public Player player;
    public SkillsMenu skillsMenu;
    public TMPro.TextMeshProUGUI loseText;
    public TMPro.TextMeshProUGUI winText;
    public Button returnButton;
    public GameObject finalBoss;
    void Start()
    {
        escapeMenu.GetComponent<Canvas>().enabled = false;
        skillMenu.GetComponent<Canvas>().enabled = false;
        winText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        loseText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        returnButton.gameObject.SetActive(false);
        finalBoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.GetComponent<Canvas>().enabled = true;
            returnButton.GetComponent<Button>().enabled = false;
            Time.timeScale = 0;
            skillsMenu.healthAmount.text = Convert.ToString(player.currentHealth);
            skillsMenu.manaAmount.text = Convert.ToString(player.currentMana);
            skillsMenu.damageAmount.text = Convert.ToString(player.playerDamage);
        }
    }
}
