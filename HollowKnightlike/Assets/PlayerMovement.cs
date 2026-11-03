using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 16f;

    [Header("Dash")]
    public bool dashEnabled = true;
    public float dashSpeed = 20f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.5f;

    [Header("Double Jump")]
    public bool doubleJumpEnabled = true;
    public float CurrentDoubleJumps;
    public float MaxDoubleJumps = 1f;

    [Header("Wall Jump")]
    public bool wallJumpEnabled = true;
    public float wallJumpForceX = 12f;
    public float wallJumpForceY = 16f;
    public bool LimitedWallJumps = false;
    public float CurrentWallJumps = 3f;
    public float MaxWallJumps = 3f;

    [Header("Coyote Time")]
    public bool coyoteTimeEnabled = true;
    public float coyoteTime = 0.15f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Wall Check")]
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public float wallCheckDistance = 0.3f;

    [SerializeField] bool touchingWallLeft;
    [SerializeField] bool touchingWallRight;

    Rigidbody2D rb;

    public float moveInput;

    public bool isGrounded;
    public bool isTouchingWall;

    public bool canDoubleJump;
    public bool isDashing;

    float coyoteTimer;
    float dashTimer;
    float dashCooldownTimer;

    public int facingDirection = 1;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (isDashing) return;

        moveInput = Input.GetAxis("Horizontal");

        CheckGround();
        CheckWall();

        HandleMovement();
        HandleJump();
        HandleDash();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            canDoubleJump = true;
            CurrentDoubleJumps = MaxDoubleJumps;
            CurrentWallJumps = MaxWallJumps;

            if (coyoteTimeEnabled)
                coyoteTimer = coyoteTime;
        }
        else
        {
            if (coyoteTimeEnabled)
                coyoteTimer -= Time.deltaTime;
        }
    }

    void CheckWall()
    {
        touchingWallLeft = Physics2D.Raycast(wallCheckLeft.position, Vector2.left, wallCheckDistance, groundLayer);
        touchingWallRight = Physics2D.Raycast(wallCheckRight.position, Vector2.right, wallCheckDistance, groundLayer);
    }


    void HandleMovement()
    {


        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);


        if (moveInput > 0)
        {
            facingDirection = 1;
            transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            facingDirection = -1;
            transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Ground Jump or Coyote Jump
            if (isGrounded || (coyoteTimeEnabled && coyoteTimer > 0))
            {
                Jump();
            }
            // Wall Jump
            else if (wallJumpEnabled && (touchingWallLeft || touchingWallRight))
            {
                WallJump();
            }
            // Double Jump
            else if (doubleJumpEnabled && canDoubleJump)
            {
                if (CurrentDoubleJumps > 0)
                {
                    Jump();
                    CurrentDoubleJumps -= 1;
                }


            }
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void WallJump()
    {
        if (!(LimitedWallJumps && CurrentWallJumps <= 0))
        {

            if (touchingWallLeft)
            {
                rb.linearVelocity = new Vector2(wallJumpForceX, wallJumpForceY);
                facingDirection = 1;
                CurrentWallJumps -= 1;
                Debug.Log("that was a wall jump");
            }
            else if (touchingWallRight)
            {
                rb.linearVelocity = new Vector2(-wallJumpForceX, wallJumpForceY);
                facingDirection = -1;
                Debug.Log("that was a wall jump");
                CurrentWallJumps -= 1;

            }
        }

    }


    void HandleDash()
    {
        if (!dashEnabled) return;

        dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }
    }

    System.Collections.IEnumerator Dash()
    {
        isDashing = true;

        dashCooldownTimer = dashCooldown;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        rb.linearVelocity = new Vector2(facingDirection * dashSpeed, 0);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;

        isDashing = false;
    }
}