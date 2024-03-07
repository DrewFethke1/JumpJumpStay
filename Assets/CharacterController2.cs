using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SecondPlayerController : MonoBehaviour
{
    public float movementSpeed2 = 5f;
    public float jumpForce = 7f;
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;
    private bool hasJumped;
    private bool isDashing;
    private float dashTimer;
    private float cooldownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation initially
        dashTimer = dashDuration;
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        // Movement
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Check for movement keys
        if (Input.GetKey(KeyCode.I))
        {
            verticalInput = -1f;
        }
        if (Input.GetKey(KeyCode.K))
        {
            verticalInput = 1f;
        }
        if (Input.GetKey(KeyCode.J))
        {
            horizontalInput = 1f;
        }
        if (Input.GetKey(KeyCode.L))
        {
            horizontalInput = -1f;
        }

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.y = 0f; // Prevents moving vertically

        transform.position += moveDirection.normalized * movementSpeed2 * Time.deltaTime;

        // Jumping
        if (Input.GetKeyDown(KeyCode.O) && isGrounded && !hasJumped)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJumped = true; // Mark that the player has jumped
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.U) && cooldownTimer <= 0)
        {
            StartCoroutine(Dash(moveDirection));
        }

        // Cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Backwards Movement (K)
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position -= transform.forward * movementSpeed2 * Time.deltaTime;
        }

        // Check if player has fallen off the map
        if (transform.position.y < -25)
        {
            Debug.Log("PLAYER 2 HAS BEEN KILLED");
            gameObject.SetActive(false); // Disable the player object
            RestartLevel();
            FindObjectOfType<ScoreDisplay>().IncrementPlayer2Win();
        }
     
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        // Apply gravity
        rb.AddForce(Vector3.down * 9.81f * rb.mass);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            hasJumped = false; // Reset jump flag when colliding with an object on the "Default" layer
        }
    }

    IEnumerator Dash(Vector3 dashDirection)
    {
        isDashing = true;
        float dashDistanceTravelled = 0f;

        while (dashDistanceTravelled < dashDistance)
        {
            float dashDistanceThisFrame = movementSpeed2 * Time.deltaTime * 10; // Increased speed for dash
            dashDistanceTravelled += dashDistanceThisFrame;
            transform.position += dashDirection * dashDistanceThisFrame;
            yield return null;
        }

        isDashing = false;
        cooldownTimer = dashCooldown;
    }
}
