using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player 1's divine light has been severed");
            Destroy(gameObject);
            IncreasePlayerSpeed(other.gameObject.GetComponent<CharacterControllerAdvanced>(), 0.25f);
        }
        else if (other.CompareTag("Player2"))
        {
            Debug.Log($"Player 2's divine light has been severed");
            Destroy(gameObject);
            IncreasePlayerSpeed(other.gameObject.GetComponent<SecondPlayerController>(), 0.25f);
        }
    }

    void IncreasePlayerSpeed(CharacterControllerAdvanced playerController, float speedIncreasePercent)
    {
        if (playerController != null)
        {
            playerController.movementSpeed *= (1 + speedIncreasePercent);
        }
    }

    void IncreasePlayerSpeed(SecondPlayerController playerController, float speedIncreasePercent)
    {
        if (playerController != null)
        {
            playerController.movementSpeed2 *= (1 + speedIncreasePercent);
        }
    }
    public float rotationSpeed = 250f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
