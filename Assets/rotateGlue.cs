using UnityEngine;

public class PlayerGluedToRotatingObject : MonoBehaviour
{
    public RotateCube rotatingObject; // Reference to the rotating object
    private bool isTouchingRotatingObject; // Flag to track whether the player is touching the rotating object

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger zone of the rotating object
        if (other.gameObject == rotatingObject.gameObject)
        {
            isTouchingRotatingObject = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the trigger zone of the rotating object
        if (other.gameObject == rotatingObject.gameObject)
        {
            isTouchingRotatingObject = false;
        }
    }

    void FixedUpdate()
    {
        // Ensure the rotating object reference is not null and the player is touching the rotating object
        if (rotatingObject != null && isTouchingRotatingObject)
        {
            // Calculate the offset vector from the player to the rotating object's center
            Vector3 offset = transform.position - rotatingObject.transform.position;

            // Apply the rotating object's rotation to the offset vector
            offset = Quaternion.Euler(0, rotatingObject.rotationSpeed * Time.fixedDeltaTime, 0) * offset;

            // Set the player's position to the sum of the rotating object's position and the offset
            transform.position = rotatingObject.transform.position + offset;
        }
    }
}
