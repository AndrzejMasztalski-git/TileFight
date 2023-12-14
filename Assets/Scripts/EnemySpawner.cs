using UnityEngine;
using Random = UnityEngine.Random;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 10.0f;
    public int maxEnemiesToSpawn = 5;
    public float spawnerHealth = 30;

    public GeneticAlgorithm geneticAlgorithm;
    public int initialSpawnCount = 10;

    void Start()
    {
        geneticAlgorithm = FindObjectOfType<GeneticAlgorithm>();
        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnEnemy(); // You'll need to decide how to initialize their genes
        }
        geneticAlgorithm.StartReproduction(); // Signal the GA to start reproducing enemies
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        // Initialize the enemy with default genes or random values
        EnemyGene initialGene = new EnemyGene(Random.Range(50, 101), Random.Range(10, 21), Random.Range(1, 6), 0f); // Example values
        enemy.GetComponent<Enemy>().InitializeEnemy(initialGene);
    }
}