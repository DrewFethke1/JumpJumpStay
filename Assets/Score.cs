using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text player1ScoreText; // Reference to the text component for Player 1's score
    public Text player2ScoreText; // Reference to the text component for Player 2's score

    public int player1Score = 0; // Score for Player 1
    public int player2Score = 0; // Score for Player 2

    // Manually assign the UI Text objects
    void Awake()
    {
        // Find the UI Text objects by searching for GameObjects with specific names
        GameObject player1ScoreObject = GameObject.Find("Player1ScoreText");
        GameObject player2ScoreObject = GameObject.Find("Player2ScoreText");

        // Get the Text components from the found GameObjects
        player1ScoreText = player1ScoreObject.GetComponent<Text>();
        player2ScoreText = player2ScoreObject.GetComponent<Text>();
    }

    // Update the HUD with the current scores
    void UpdateHUD()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
    }

    // Increment Player 1's score
    public void IncrementPlayer1Score()
    {
        player1Score++;
        UpdateHUD();
    }

    // Increment Player 2's score
    public void IncrementPlayer2Score()
    {
        player2Score++;
        UpdateHUD();
    }
}
