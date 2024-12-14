using UnityEngine;

public class RandomizeObject : MonoBehaviour
{
    [Header("Position Randomization")]
    public bool randomizePosition = true;
    public Vector3 minPosition = new Vector3(-100, 0, -100);
    public Vector3 maxPosition = new Vector3(10099, 0, 10000);

    [Header("Road Settings")]
    public bool avoidRoad = true;        // Toggle road avoidance
    public GameObject roadObject;        // Reference to the road object
    private Bounds roadBounds;           // Holds the road boundaries

    [Header("Ground Settings")]
    public LayerMask groundLayer;        // Layer to detect the ground
    public float raycastHeight = 10f;    // Height from which to cast the ray

    private void Awake()
    {
        // Automatically set road boundaries if roadObject is assigned
        if (avoidRoad && roadObject != null)
        {
            Renderer roadRenderer = roadObject.GetComponent<Renderer>();
            if (roadRenderer != null)
            {
                roadBounds = roadRenderer.bounds;
            }
            else
            {
                Debug.LogWarning("Road object does not have a Renderer component. Boundaries cannot be calculated.");
            }
        }

        if (randomizePosition)
        {
            Vector3 randomPosition;

            do
            {
                // Generate a random position
                randomPosition = new Vector3(
                    Random.Range(minPosition.x, maxPosition.x),
                    0, // Y will be adjusted by Raycast
                    Random.Range(minPosition.z, maxPosition.z)
                );

            } while (avoidRoad && IsInsideRoad(randomPosition)); // Re-randomize if within the road

            // Adjust Y to the ground level
            transform.position = GetGroundPosition(randomPosition);
        }
    }

    private bool IsInsideRoad(Vector3 position)
    {
        // Check if the position is within the road bounds
        return roadBounds.Contains(position);
    }

    private Vector3 GetGroundPosition(Vector3 position)
    {
        Ray ray = new Ray(new Vector3(position.x, raycastHeight, position.z), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            // If the ray hits the ground, return the adjusted position
            return new Vector3(position.x, hit.point.y, position.z);
        }

        Debug.LogWarning($"No ground detected at position: {position}");
        return position; // Fallback to original position if no ground is detected
    }
}
