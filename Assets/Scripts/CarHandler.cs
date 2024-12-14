using UnityEngine;

public class CarHandler : MonoBehaviour
{
    // [SerializeField] private Rigidbody rb;

    // // Multipliers
    // [SerializeField] private float accelerationMultiplier = 3f;
    // float breaksMultiplier = 15f;

    // // Input
    // private Vector2 input = Vector2.zero;

    // // Called before the first frame update
    // private void Start()
    // {
    //     // Initialization logic (if any) goes here
    // }

    // // Called once per frame
    // private void Update()
    // {
    //     // Capture player input
    //     input.x = Input.GetAxis("Horizontal");
    //     input.y = Input.GetAxis("Vertical");
    // }

    // // Called at fixed time intervals
    // private void FixedUpdate()
    // {
    //     if(input.y > 0) {
    //         Accelerate();
    //     } else {
    //         rb.drag = 0.2f;
    //     }

    //     if(input.y < 0) {
    //         Brake();
    //     }
    // }

    // // Handles acceleration logic
    // private void Accelerate()
    // {
    //     rb.drag = 0; // Reset drag
    //     rb.AddForce(rb.transform.forward * accelerationMultiplier * input.y);
    // }

    // void Brake()
    // {
    //     if(rb.velocity.z <= 0) {
    //         return;
    //     }
    //     rb.AddForce(rb.transform.forward * breaksMultiplier * input.z);
    // }
}
