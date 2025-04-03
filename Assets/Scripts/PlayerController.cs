using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables for movement (editable for debugging)
    public float movementSpeed = 5f; // Default speed, adjustable via UI
    public float maxMovementSpeed = 15f; // Cap for movement speed
    public float jumpHeight = 5f;
    public float maxJumpHeight = 15f;
    public string jumpStatus = "disabled";
    public bool isGrounded = false;
    public bool canPassForceField = false;

    // Components
    private Rigidbody2D rb;
    private Transform groundCheck;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    // Input variables
    private float moveInput;

    // UI control
    public GameObject debugUI;
    private bool isUIOpen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        if (debugUI != null) debugUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!isUIOpen)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpStatus == "enabled")
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUI();
        }
    }

    void FixedUpdate()
    {
        if (!isUIOpen)
        {
            float moveVelocity = moveInput * movementSpeed;
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    // Public methods for UI to modify variables
    public void SetJumpHeight(float newHeight)
    {
        jumpHeight = Mathf.Clamp(newHeight, 0f, maxJumpHeight);
    }

    public void SetJumpStatus(string newStatus)
    {
        jumpStatus = newStatus;
    }

    public void SetForceFieldStatus(bool newStatus)
    {
        canPassForceField = newStatus;
    }

    public void SetMovementSpeed(float newSpeed)
    {
        movementSpeed = Mathf.Clamp(newSpeed, 1f, maxMovementSpeed); // Range: 1 to 10
    }

    private void ToggleUI()
    {
        isUIOpen = !isUIOpen;
        debugUI.SetActive(isUIOpen);
        Time.timeScale = isUIOpen ? 0f : 1f;
        Cursor.visible = isUIOpen;
        Cursor.lockState = isUIOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void CloseUI()
    {
        isUIOpen = false;
        debugUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}