using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public int player1Score = 10;
    public int player2Score = 10;
    private bool canScore = true;
    [SerializeField] private float scoreCooldown = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (canScore)
        {
            GameObject otherPlayer = other.gameObject;
            Vector3 otherPlayerPosition = otherPlayer.transform.position;
            Vector3 thisPlayerPosition = transform.position;

            if ((other.CompareTag("Player1") && gameObject.CompareTag("Player2")) ||
                (other.CompareTag("Player2") && gameObject.CompareTag("Player1")))
            {
                if (thisPlayerPosition.y > otherPlayerPosition.y)
                {
                    Debug.Log("Player " + (gameObject.CompareTag("Player") ? "1" : "2") + " jumped over the other player!");

                    if (gameObject.CompareTag("Player1"))
                    {
                        player1Score--;
                        Debug.Log("Player 1 Health: " + player1Score);
                        FindObjectOfType<ScoreDisplay>().IncrementPlayer1Score();  
                        CheckPlayer1Score();
                    }
                    else if (gameObject.CompareTag("Player2"))
                    {
                        player2Score--;
                        Debug.Log("Player 2 Health: " + player2Score);
                        FindObjectOfType<ScoreDisplay>().IncrementPlayer2Score();
                        CheckPlayer2Score();
                    }

                    canScore = false;
                    Invoke(nameof(ResetScoreCooldown), scoreCooldown);
                }
            }
        }
    }

    public void CheckPlayer1Score()
    {
        if (player1Score <= -10)
        {
     

            GameObject[] player2Objects = GameObject.FindGameObjectsWithTag("Player2");

            foreach (GameObject player2 in player2Objects)
            {
                Collider collider = player2.GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
            Debug.Log("PLAYER 2 HAS BEEN KNOCKED THE FUCK OUT.");
        }
    }



    public void CheckPlayer2Score()
    {
        if (player2Score <= -10)
        {
            Debug.Log("PLAYER 1 HAS BEEN KNOCKED THE FUCK OUT.");
            GameObject player1 = GameObject.FindGameObjectWithTag("Player");
            if (player1 != null)
            {
                Collider collider = player1.GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = false;
                    Debug.Log("PLAYER 1 HAS BEEN KNOCKED THE FUCK OUT.");
                }
            }
        }
    }

    private void ResetScoreCooldown()
    {
        canScore = true;
    }
}
