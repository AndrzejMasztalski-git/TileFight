using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana;
    [SerializeField] ManaBar manaBar;
    [SerializeField] HealthBar healthBar;

    
    void Start()
    {
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
