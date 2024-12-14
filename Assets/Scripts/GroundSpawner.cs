using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;  // Prefab for the ground segment
    public Transform player;         // Reference to the player
    public float spawnDistance = 100f; // Distance ahead to spawn new segments
    public float segmentLength = 10f; // Length of each ground segment

    private float nextSpawnZ;

    void Start()
    {
        // Initialize the next spawn position
        nextSpawnZ = player.position.z;
    }

    void Update()
    {
        // Spawn ground segments as the player moves forward
        while (player.position.z + spawnDistance > nextSpawnZ)
        {
            SpawnGroundSegment(nextSpawnZ);
            nextSpawnZ += segmentLength;
        }
    }

    void SpawnGroundSegment(float zPosition)
    {
        Instantiate(groundPrefab, new Vector3(0, 0, zPosition), Quaternion.identity);
    }
}
