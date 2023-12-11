using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillsMenu : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI manaAmount;
    public TextMeshProUGUI damageAmount;
    public Canvas skillsMenu;
    public GameManager gameManager;
    public TextMeshProUGUI skillPointsAmount;


    
    void Update()
    {
        skillPointsAmount.text = Convert.ToString(player.skillPoints);
    }

    public void AddHealthClicked()
    {
        if (player.skillPoints > 0)
        {
            player.AddHealth(10);
            healthAmount.text = Convert.ToString(player.currentHealth);
            player.skillPoints--;
        }
        else
        {
            Debug.Log("Brak puntków awansu!");
        }
    }

    public void AddManaClicked()
    {
        if (player.skillPoints > 0)
        {
            player.AddMana(10);
            manaAmount.text = Convert.ToString(player.currentMana);
            player.skillPoints--;
        }
        else
        {
            Debug.Log("Brak puntków awansu!");
        }
    }

    public void AddDamageClicked()
    {
        if(player.skillPoints > 0)
        {
            player.AddDamage(10);
            damageAmount.text = Convert.ToString(player.playerDamage);
            player.skillPoints--;
        }
        else
        {
            Debug.Log("Brak puntków awansu!");
        }
        
    }

    public void BackButtonClicked()
    {
        gameManager.escapeMenu.GetComponent<Canvas>().enabled = true;
        skillsMenu.GetComponent<Canvas>().enabled = false;
    }


}
