using TMPro;
using System.Collections.Generic;
using UnityEngine;


public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    void Awake()
    {

        if (player1ScoreText == null || player2ScoreText == null)
        {
            Debug.LogError("TextMeshPro Text objects are not assigned!");
            return;
        }


        UpdateHUD();
    }


    void UpdateHUD()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
    }

    public void IncrementPlayer1Score()
    {
        player1Score++;
        UpdateHUD();
    }

    public void IncrementPlayer2Score()
    {
        player2Score++;
        UpdateHUD();
    }
}