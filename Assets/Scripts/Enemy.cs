using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int speed;
    public int damage = 15;
    public Player player;
    public EnemyHealthBar enemyHealthBar;


    public void SetupStats(int health, int attack, int enemySpeed)
    {
        currentHealth = health;
        maxHealth = health;
        damage = attack;
        speed = enemySpeed;

        if (enemyHealthBar != null)
        {
            enemyHealthBar.SetMaxHealth(maxHealth);
            enemyHealthBar.SetHealth(currentHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fireball")
        {
            TakeDamage(player.playerDamage);
        }
    }

    public void TakeDamage(int healthTaken)
    {
        currentHealth -= healthTaken;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (enemyHealthBar != null)
        {
            enemyHealthBar.SetHealth(currentHealth);
        }
    }

    

    public void InitializeEnemy(EnemyGene gene)
    {
        // Use the gene's values to set the enemy's properties
        maxHealth = gene.health;
        currentHealth = gene.health;
        damage = gene.damage;
        speed = gene.speed;
        // Assume that the `EnemyHealthBar` is already set up to reflect changes
    }
}