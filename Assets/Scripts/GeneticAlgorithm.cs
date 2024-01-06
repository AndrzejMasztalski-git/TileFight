using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeneticAlgorithm : MonoBehaviour
{
    
    

    // List to hold the current population of enemy genes
    private List<EnemyGene> population = new List<EnemyGene>();
    private int populationSize = 5;
    private float mutationRate = 0.01f;
    public GameObject enemyPrefab;
    public GameObject spawner;
    public Text hpStat;
    public Text dmgStat;

    void Start()
    {
        InitializePopulation();
    }

    
    private void InitializePopulation()
    {
        for (int i = 0; i < populationSize; i++)
        {
            population.Add(new EnemyGene(
                Random.Range(50, 101), // Health
                Random.Range(10, 21),  // Damage
                Random.Range(1, 6),    // Speed
                0f                     // Fitness
            ));
        }
    }

    
    public void EvolvePopulation()
    {
        CalculateFitness(); 

        List<EnemyGene> newPopulation = new List<EnemyGene>();

        
        for (int i = 0; i < populationSize; i++)
        {
            EnemyGene parent1 = SelectParent();
            EnemyGene parent2 = SelectParent();
            EnemyGene offspring = Crossover(parent1, parent2);
            offspring = Mutate(offspring);
            newPopulation.Add(offspring);
        }

        population = newPopulation;
    }

    
    private void CalculateFitness()
    {
        
        const float healthWeight = 0.4f;
        const float damageWeight = 0.3f;
        const float speedWeight = 0.3f;

        
        const int maxHealth = 200;
        const int maxDamage = 50;
        const int maxSpeed = 10;

        foreach (var gene in population)
        {
            
            float normalizedHealth = (float)gene.health / maxHealth;
            float normalizedDamage = (float)gene.damage / maxDamage;
            float normalizedSpeed = (float)gene.speed / maxSpeed;

            
            gene.fitness = (normalizedHealth * healthWeight) + (normalizedDamage * damageWeight) + (normalizedSpeed * speedWeight);
        }
    }

    
    public EnemyGene SelectParent()
    {
        
        float totalFitness = population.Sum(gene => gene.fitness);

        
        float randomNumber = Random.Range(0f, totalFitness);

        
        float runningSum = 0;
        foreach (EnemyGene gene in population)
        {
            runningSum += gene.fitness;
            if (runningSum > randomNumber)
            {
                return gene;
            }
        }

       
        return population[Random.Range(0, population.Count)];
    }

    
    private EnemyGene Crossover(EnemyGene parent1, EnemyGene parent2)
    {
       
        return new EnemyGene(
            (parent1.health + parent2.health) * 3 / 2,
            (parent1.damage + parent2.damage) * 3 / 2,
            (parent1.speed + parent2.speed) * 3 / 2,
            0f 
        );
    }

    
    private EnemyGene Mutate(EnemyGene gene)
    {
        
        if (Random.Range(0f, 1f) < mutationRate)
        {
            
            gene.health = Mathf.Clamp(gene.health + Random.Range(5, 16), 50, 200);
            gene.damage = Mathf.Clamp(gene.damage + Random.Range(3, 11), 10, 40);
            gene.speed = Mathf.Clamp(gene.speed + Random.Range(1, 5), 3, 9);
        }
        return gene;
    }

    public void StartReproduction()
    {
        InvokeRepeating("ReproduceEnemy", 2.0f, 1.0f);
    }

    public void ReproduceEnemy()
    {
        
        EnemyGene parentGene = SelectParent();
        EnemyGene newGene = Mutate(Crossover(parentGene, SelectParent()));

        
        Vector3 spawnPosition = spawner.transform.position;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        newEnemy.GetComponent<SpriteRenderer>().color = Color.green;
        newEnemy.GetComponent<Enemy>().InitializeEnemy(newGene);

        hpStat.text = newEnemy.GetComponent<Enemy>().currentHealth.ToString();
        dmgStat.text = newEnemy.GetComponent<Enemy>().damage.ToString();
    }
}

