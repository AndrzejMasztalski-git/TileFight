using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefabrykat przeciwnika do spawnowania
    public Transform spawnPoint; // Pozycja, gdzie przeciwnik bêdzie spawnowany
    public float spawnInterval = 10.0f; // Czas miêdzy kolejnymi spawnami (10 sekund)
    public int enemiesSpawned;
    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0.0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPoint != null && enemiesSpawned<5)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemiesSpawned++;
        }
    }
}
