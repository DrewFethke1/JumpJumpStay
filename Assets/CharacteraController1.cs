using System.Collections;
using UnityEngine;

public class CharacterControllerAdvanced : MonoBehaviour
{
    public float movementSpeed = 5f;
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
    private Vector3 lastMoveDirection = Vector3.forward;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Invert controls
        horizontalInput *= -1f;
        verticalInput *= -1f;

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.y = 0f; // Prevents moving vertically

        if (!isDashing)
        {
            transform.position += moveDirection.normalized * movementSpeed * Time.deltaTime;

            // Update last move direction if there is movement
            if (moveDirection != Vector3.zero)
            {
                lastMoveDirection = moveDirection.normalized;
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.E) && isGrounded && !hasJumped)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJumped = true; // Mark that the player has jumped
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.Q) && cooldownTimer <= 0)
        {
            StartCoroutine(Dash(lastMoveDirection));
        }

        // Cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Backwards Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;
        }

        // Check if player has fallen off the map
        if (transform.position.y < -25)
        {
            Debug.Log("PLAYER 1 HAS BEEN KILLED");
            gameObject.SetActive(false); // Disable the player object
        }
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
            float dashDistanceThisFrame = movementSpeed * Time.deltaTime * 10; // Increased speed for dash
            dashDistanceTravelled += dashDistanceThisFrame;
            transform.position += dashDirection * dashDistanceThisFrame;
            yield return null;
        }

        isDashing = false;
        cooldownTimer = dashCooldown;
    }
}
