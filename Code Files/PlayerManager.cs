using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpTime = 0.35f; // Maximum Jump Time
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    public float fallThreshold = -20f;  // Drop Determination Threshold
    public GameObject gameOverPanel;    // Game Over Panel

    private CharacterController controller;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;

    private bool isGameOver = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
            Debug.LogError("The CharacterController component is missing.");
    }

    void Update()
    {
        if (isGameOver)
            return;

        HandleMovement();
        HandleJump();

        if (transform.position.y < fallThreshold && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void HandleMovement()
    {
        // Move horizontally
        float moveInput = Input.GetAxis("Horizontal");
        controller.Move(new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0));
    }

    void HandleJump()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                controller.Move(Vector3.up * jumpForce * Time.deltaTime);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        // Restart the game to reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
