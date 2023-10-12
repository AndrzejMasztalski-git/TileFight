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
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
        enemyHealthBar.SetHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball")
        {
            TakeDamage(player.playerDamage);
        }
    }


    public void TakeDamage(int healthTaken)
    {
        currentHealth -= healthTaken;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        enemyHealthBar.SetHealth(currentHealth);
    }
}
