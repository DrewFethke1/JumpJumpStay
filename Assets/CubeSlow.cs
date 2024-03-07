using System.Collections;
using UnityEngine;

public class SpeedDecreaseCube : MonoBehaviour
{
    private bool isKnocked = false;
    private string knockingPlayer;

    void Start()
    {
        StartCoroutine(IncreasePlayerSpeedOverTime());
    }

    void Update()
    {
        if (!isKnocked && transform.position.y < -45f)
        {
            isKnocked = true;
            StartCoroutine(DecreasePlayerSpeed());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isKnocked && (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Player2")))
        {
            knockingPlayer = collision.collider.CompareTag("Player") ? "Player 1" : "Player 2";
        }
    }

    IEnumerator DecreasePlayerSpeed()
    {
        float speedDecreaseRate = 0.25f;
        float timeToDecrease = 2f;
        float elapsedTime = 0f;

        CharacterControllerAdvanced player1Controller = FindObjectOfType<CharacterControllerAdvanced>();
        SecondPlayerController player2Controller = FindObjectOfType<SecondPlayerController>();

        if (knockingPlayer == "Player 1" && player2Controller != null)
        {
            Debug.Log("PLAYER 2 HAS BEEN WEAKENED.");
            while (elapsedTime < timeToDecrease)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                player2Controller.movementSpeed2 *= (1 - speedDecreaseRate * Time.deltaTime);
            }
        }
        else if (knockingPlayer == "Player 2" && player1Controller != null)
        {
            Debug.Log("PLAYER 1 HAS BEEN WEAKENED.");
            while (elapsedTime < timeToDecrease)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                player1Controller.movementSpeed *= (1 - speedDecreaseRate * Time.deltaTime);
            }
        }
    }

    IEnumerator IncreasePlayerSpeedOverTime()
    {
        float speedIncreaseRate = 0.005f; // Adjust this value to control the speed increase rate
        WaitForSeconds delay = new WaitForSeconds(1f); // Adjust the delay time as needed

        while (true)
        {
            yield return delay;

            CharacterControllerAdvanced player1Controller = FindObjectOfType<CharacterControllerAdvanced>();
            SecondPlayerController player2Controller = FindObjectOfType<SecondPlayerController>();

            if (player1Controller != null)
            {
                player1Controller.movementSpeed += speedIncreaseRate;
            }

            if (player2Controller != null)
            {
                player2Controller.movementSpeed2 += speedIncreaseRate;
            }
        }
    }
}
