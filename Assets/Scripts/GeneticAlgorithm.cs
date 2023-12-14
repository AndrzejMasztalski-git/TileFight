using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    
    

    // List to hold the current population of enemy genes
    private List<EnemyGene> population = new List<EnemyGene>();
    private int populationSize = 5;
    private float mutationRate = 0.01f;
    public GameObject enemyPrefab;
    public GameObject spawner;

    void Start()
    {
        InitializePopulation();
    }

    // Initializes the population with random genes and default fitness
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

    // Function to evolve the population
    public void EvolvePopulation()
    {
        CalculateFitness(); // Calculate the fitness for each gene

        List<EnemyGene> newPopulation = new List<EnemyGene>();

        // Select parents and create new offspring
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

    // Calculate fitness for each gene (to be implemented based on your game's logic)
    private void CalculateFitness()
    {
        // Constants to define the importance (weight) of each aspect (health, damage, speed) in the fitness calculation
        const float healthWeight = 0.4f;
        const float damageWeight = 0.3f;
        const float speedWeight = 0.3f;

        // Assuming that you have maximum possible values for health, damage, and speed to normalize these values
        const int maxHealth = 200;
        const int maxDamage = 50;
        const int maxSpeed = 10;

        foreach (var gene in population)
        {
            // Normalize the health, damage, and speed to be between 0 and 1
            float normalizedHealth = (float)gene.health / maxHealth;
            float normalizedDamage = (float)gene.damage / maxDamage;
            float normalizedSpeed = (float)gene.speed / maxSpeed;

            // Calculate the fitness as a weighted sum of these normalized values
            gene.fitness = (normalizedHealth * healthWeight) + (normalizedDamage * damageWeight) + (normalizedSpeed * speedWeight);
        }
    }

    // Selects a parent for breeding based on fitness
    public EnemyGene SelectParent()
    {
        // Calculate the total fitness of the population.
        float totalFitness = population.Sum(gene => gene.fitness);

        // Generate a random number between 0 and the total fitness.
        float randomNumber = Random.Range(0f, totalFitness);

        // Go through the population and sum fitnesses from 0, until the sum reaches the random number.
        float runningSum = 0;
        foreach (EnemyGene gene in population)
        {
            runningSum += gene.fitness;
            if (runningSum > randomNumber)
            {
                return gene;
            }
        }

        // As a fallback, if something goes wrong, return a random gene.
        // This should not normally happen, but it's good to have a fail-safe.
        return population[Random.Range(0, population.Count)];
    }

    // Combines genes from two parents to create an offspring
    private EnemyGene Crossover(EnemyGene parent1, EnemyGene parent2)
    {
        // Simple average crossover
        return new EnemyGene(
            (parent1.health + parent2.health) / 2,
            (parent1.damage + parent2.damage) / 2,
            (parent1.speed + parent2.speed) / 2,
            0f // Reset fitness for the offspring
        );
    }

    // Randomly mutates the genes of an offspring
    private EnemyGene Mutate(EnemyGene gene)
    {
        // Increase mutation impact by adjusting the range of possible changes.
        if (Random.Range(0f, 1f) < mutationRate)
        {
            // Adjust values to ensure that mutations lead to stronger enemies over time.
            gene.health = Mathf.Clamp(gene.health + Random.Range(5, 16), 50, 200); // Increased upper limit
            gene.damage = Mathf.Clamp(gene.damage + Random.Range(3, 11), 10, 40); // Increased upper limit
            gene.speed = Mathf.Clamp(gene.speed + Random.Range(1, 5), 1, 15); // Increased upper limit
        }
        return gene;
    }

    public void StartReproduction()
    {
        InvokeRepeating("ReproduceEnemy", 2.0f, 25.0f);
    }

    public void ReproduceEnemy()
    {
        // Instead of iterating over all enemies, just reproduce one at a time.
        EnemyGene parentGene = SelectParent(); // Select one parent based on fitness.
        EnemyGene newGene = Mutate(Crossover(parentGene, SelectParent())); // Create a new gene from two parents.

        // Spawn a new enemy with the new gene at a specific location or near a parent.
        Vector3 spawnPosition = spawner.transform.position;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().InitializeEnemy(newGene);
    }
}

