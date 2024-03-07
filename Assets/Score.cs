using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
    public TMP_Text player1WinText;
    public TMP_Text player2WinText;

    private int player1Score = 10;
    private int player2Score = 10;
    private int player1Win;
    private int player2Win;

    void Awake()
    {
        if (player1ScoreText == null || player2ScoreText == null)
        {
            Debug.LogError("TextMeshPro Text objects are not assigned!");
            return;
        }

        // Load player win values from PlayerPrefs
        player1Win = PlayerPrefs.GetInt("Player1Wins", 0);
        player2Win = PlayerPrefs.GetInt("Player2Wins", 0);

        UpdateHUD();
    }

    void UpdateHUD()
    {
        player1ScoreText.text = "Player 1 Health: " + player2Score.ToString();
        player2ScoreText.text = "Player 2 Health: " + player1Score.ToString();
        player1WinText.text = "Player 1 Wins: " + player2Win.ToString();
        player2WinText.text = "Player 2 Wins: " + player1Win.ToString();
    }

    public void IncrementPlayer1Score()
    {
        Debug.Log("PLAYER");
        player1Score--;
        UpdateHUD();
    }

    public void IncrementPlayer2Score()
    {
        player2Score--;
        UpdateHUD();

    }

    public void IncrementPlayer1Win()
    {
        player1Win++;
        PlayerPrefs.SetInt("Player1Wins", player1Win); // Save player1Win to PlayerPrefs
        UpdateHUD();
    }

    public void IncrementPlayer2Win()
    {
        player2Win++;
        PlayerPrefs.SetInt("Player2Wins", player2Win); // Save player2Win to PlayerPrefs
        UpdateHUD();
    }

    [RuntimeInitializeOnLoadMethod]
    static void ResetPlayerScores()
    {
        // Reset player scores when Unity play mode starts
        PlayerPrefs.DeleteKey("Player1Wins");
        PlayerPrefs.DeleteKey("Player2Wins");
    }
    


}

