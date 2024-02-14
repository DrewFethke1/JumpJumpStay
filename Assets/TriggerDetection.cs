using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public string playerTag; // Tag of the player this trigger belongs to
    private int playerIndex; // Index of the player (1 or 2)
    private int player1Score = 0; // Score for Player 1
    private int player2Score = 0; // Score for Player 2

    void Start()
    {
        // Determine the player index based on the player tag
        playerIndex = playerTag == "Player1" ? 1 : 2;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger has the tag of the other player
        if ((other.CompareTag("Player1") && playerTag == "Player2") ||
            (other.CompareTag("Player2") && playerTag == "Player1"))
        {
            // A player has jumped over the other player
            Debug.Log("Player " + playerIndex + " jumped over the other player!");

            // Increment the score for the corresponding player
            if (playerIndex == 1)
            {
                player1Score++;
                Debug.Log("Player 1 Score: " + player1Score);
            }
            else
            {
                player2Score++;
                Debug.Log("Player 2 Score: " + player2Score);
            }
        }
    }
}
