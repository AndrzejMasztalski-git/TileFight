using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana;
    public int playerDamage;
    public int keyCounter = 0;
    [SerializeField] ManaBar manaBar;
    [SerializeField] HealthBar healthBar;

    string[] boosts = { "hp", "damage", "mana" };

    
    void Start()
    {
        playerDamage = 10;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
        manaBar.SetMana(maxMana);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            TakeDamage(10);
        }

        if (collision.tag == "Key")
        {
            keyCounter++;
            Destroy(collision.gameObject);
        }


        if (collision.tag == "Chest")
        {
            Debug.Log("Chest opened!");
            System.Random rand = new();
            int index = rand.Next(boosts.Length);

            string chosenBoost = boosts[index];

            if(chosenBoost == "hp")
            {
                Debug.Log("hp added");
                maxHealth += 10;
                healthBar.SetMaxHealth(maxHealth);
                Destroy(collision.gameObject);
            }
            else if(chosenBoost == "damage")
            {
                Debug.Log("damage added");
                playerDamage += 5;
                Destroy(collision.gameObject);
            }
            else if(chosenBoost == "mana")
            {
                Debug.Log("mana added");
                maxMana += 10;
                manaBar.SetMaxMana(maxMana);
                Destroy(collision.gameObject);
            }

            
        }


    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            UseMana(5);
            manaBar.SetMana(currentMana);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void UseMana(int usedMana)
    {
        currentMana -= usedMana;
        manaBar.SetMana(currentMana);
    }
}
