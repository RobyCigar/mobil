using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public GameObject[] obstaclePrefabs;  // Array to hold different obstacle prefabs
    public Transform road;                // Reference to the road object
    public float spawnInterval = 2f;      // Time between each obstacle spawn
    public float spawnDistance = 20f;     // Distance ahead of the car to spawn obstacles
    public float minOffset = -2f;         // Minimum X offset from the center of the road
    public float maxOffset = 2f;          // Maximum X offset from the center of the road

    [Header("Cleanup Settings")]
    public float cleanupDistance = 10f;  // Distance behind the camera to destroy obstacles

    private float nextSpawnTime;

    void Update()
    {
        // Handle continuous obstacle spawning
        if (Time.time > nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnInterval;
        }

        // Clean up obstacles behind the camera
        CleanupObstacles();
    }

    void SpawnObstacle()
    {
        // Calculate spawn position
        float randomZ = Camera.main.transform.position.z + spawnDistance; // Spawn ahead of the camera
        float randomX = Random.Range(minOffset, maxOffset);              // Random X offset within bounds

        Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);

        // Randomly select an obstacle prefab
        GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Instantiate the obstacle
        Instantiate(randomObstacle, spawnPosition, Quaternion.identity);
    }

    void CleanupObstacles()
    {
        // Find all obstacles with the "Obstacle" tag
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            // Destroy obstacles that are far behind the camera
            if (obstacle.transform.position.z < Camera.main.transform.position.z - cleanupDistance)
            {
                Destroy(obstacle);
            }
        }
    }
}
