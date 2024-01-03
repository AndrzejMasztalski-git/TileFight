using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene
{
    
    
        public int health;
        public int damage;
        public int speed;
        public float fitness;

        public EnemyGene(int health, int damage, int speed, float fitness)
        {
            this.health = health;
            this.damage = damage;
            this.speed = speed;
            this.fitness = fitness;
        }
    
}
