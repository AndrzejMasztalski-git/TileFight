using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana = 100;
    public int playerDamage = 10;
    public int keyCounter = 0;
    public int skillPoints = 0;
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
            skillPoints++;
            Destroy(collision.gameObject);
            


        }


    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            UseMana(5);
            manaBar.SetMana(currentMana);
        }

        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    public void AddMana(int mana)
    {
        currentMana += mana;
        manaBar.SetMana(currentMana);
    }

    public void AddDamage(int damage)
    {
        playerDamage += damage;
    }

    void UseMana(int usedMana)
    {
        currentMana -= usedMana;
        manaBar.SetMana(currentMana);
    }
}
