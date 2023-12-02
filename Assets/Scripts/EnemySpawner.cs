using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 10.0f;
    public int maxEnemiesToSpawn = 5;
    private int enemiesSpawned = 0;
    private float timeSinceLastSpawn = 0.0f;
    public float spawnerHealth = 30;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && enemiesSpawned < maxEnemiesToSpawn)
        {
            SpawnEnemyWithRandomStats();
            timeSinceLastSpawn = 0.0f;
        }
    }

    public void SpawnEnemyWithRandomStats()
    {
        if (enemyPrefab != null && spawnPoint != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                // Losowanie statystyk
                int randomHealth = Random.Range(50, 150); // Zakres ¿ycia od 50 do 150
                int randomAttack = Random.Range(10, 30);   // Zakres ataku od 10 do 30
                int randomSpeed = Random.Range(3, 8);     // Zakres szybkoœci od 3 do 8

                enemyComponent.SetupStats(randomHealth, randomAttack, randomSpeed);
            }

            enemiesSpawned++;
        }
    }

    public void DestroySpawner()
    {
        Destroy(gameObject);
    }
}