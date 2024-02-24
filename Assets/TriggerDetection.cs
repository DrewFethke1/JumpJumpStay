using UnityEngine;
using TMPro;

public class TriggerDetection : MonoBehaviour
{
    public string playerTag;
    private int playerIndex;
    private int player1Score = 0;
    private int player2Score = 0;
    private bool canScore = true;
    [SerializeField] private float scoreCooldown = 0.2f;

    private void Start()
    {
        playerIndex = playerTag == "Player1" ? 1 : 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canScore)
        {
            GameObject otherPlayer = other.gameObject;
            Vector3 otherPlayerPosition = otherPlayer.transform.position;
            Vector3 thisPlayerPosition = transform.position;

            if ((other.CompareTag("Player1") && playerTag == "Player2") ||
                (other.CompareTag("Player2") && playerTag == "Player1"))
            {
                if (thisPlayerPosition.y > otherPlayerPosition.y)
                {
                    Debug.Log("Player " + playerIndex + " jumped over the other player!");

                    if (playerIndex == 1 && other.CompareTag("Player2"))
                    {
                        player1Score++;
                        Debug.Log("Player 1 Score: " + player1Score);
                        FindObjectOfType<ScoreDisplay>().IncrementPlayer1Score();
                    }
                    else if (playerIndex == 2 && other.CompareTag("Player1"))
                    {
                        player2Score++;
                        Debug.Log("Player 2 Score: " + player2Score);
                        FindObjectOfType<ScoreDisplay>().IncrementPlayer2Score();
                    }

                    canScore = false;
                    Invoke(nameof(ResetScoreCooldown), scoreCooldown);
                }
            }
        }
    }

    private void ResetScoreCooldown()
    {
        canScore = true;
    }
}
