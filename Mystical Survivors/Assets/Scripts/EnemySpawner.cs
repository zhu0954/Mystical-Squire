using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    public int swarmSize = 5;  // Number of enemies in a swarm

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
            return;
        }

        InvokeRepeating("SpawnEnemySwarm", spawnInterval, spawnInterval);
    }

    void SpawnEnemySwarm()
    {
        for (int i = 0; i < swarmSize; i++)
        {
            SpawnEnemyNearPlayer();
        }
    }

    void SpawnEnemyNearPlayer()
    {
        if (player != null)
        {
            Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
