using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float laneDistance = 2.0f; // Distance between lanes
    public float moveSpeed = 10f;    // Forward speed of the player
    public float laneChangeSpeed = 10f; // Speed to move to another lane

    private int currentLane = 1; // 0 = Left, 1 = Center, 2 = Right
    private Vector3 targetPosition;

    void Start()
    {
        // Initialize the target position to the starting position
        targetPosition = transform.position;
    }

void Update()
{
    // Move forward continuously
    // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    // // Check for input for lane switching
    // if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
    // {
    //     currentLane--;
    //     UpdateTargetPosition();
    // }
    // if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane <= 2)
    // {
    //     currentLane++;
    //     UpdateTargetPosition();
    // }

    // // Smoothly move to the target lane
    // transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
}


    void UpdateTargetPosition()
    {
        // Calculate the new target position based on the current lane
        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);
    }
}
