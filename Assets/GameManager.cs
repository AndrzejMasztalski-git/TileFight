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
    void Start()
    {
        escapeMenu.GetComponent<Canvas>().enabled = false;
        skillMenu.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            skillsMenu.healthAmount.text = Convert.ToString(player.currentHealth);
            skillsMenu.manaAmount.text = Convert.ToString(player.currentMana);
            skillsMenu.damageAmount.text = Convert.ToString(player.playerDamage);
        }
    }
}
