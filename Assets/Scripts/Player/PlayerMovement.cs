using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private int maxJumps;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private int groundPoundForce;
    [SerializeField] private float wallSlideSpeed;
    [SerializeField] private float dashDuration;

    private Rigidbody2D body;
    private int jumps;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private bool isWallSliding;
    private int wallDirX;
    private float horizontalInput;
    private bool isGroundPounding;
    private float groundPoundDelay = 0.12f;
    private float groundPoundTimer;
    private bool isMidAirSpinning;
    private float midAirSpinDuration = 0.10f;
    private float midAirSpinTimer;
    private float midAirSpinCooldown;
    private bool isDashing;
    private float dashTimer;
    private float dashCooldown;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), transform.localScale.y, transform.localScale.z);
        }
        if (wallJumpCooldown <= 0f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
        wallDirX = WallDirection();

        if (Input.GetKeyDown(KeyCode.Space) && !isGroundPounding)
        {
            if (IsGrounded()) Jump();

            else if (OnWall()) WallJump();

            else if (jumps > 0) Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && (dashCooldown <= 0f)) Dash();

        if (Input.GetKeyDown(KeyCode.S) && !isGroundPounding) GroundPound();

        if (Input.GetKeyDown(KeyCode.Q) && !IsGrounded() && (midAirSpinCooldown <= 0f)) MidAirSpin();

        if (IsGrounded() || OnWall()) jumps = maxJumps;

        if (wallDirX != 0 && horizontalInput == wallDirX && !IsGrounded() && wallJumpCooldown <= 0f)
        {
            isWallSliding = true;
            body.velocity = new Vector2(body.velocity.x, -wallSlideSpeed);
        }
        else
        {
            isWallSliding = false;
        }

        if (wallJumpCooldown > 0) wallJumpCooldown -= Time.deltaTime;

        if (dashCooldown > 0) dashCooldown -= Time.deltaTime;

        if (midAirSpinCooldown > 0) midAirSpinCooldown -= Time.deltaTime;

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer > 0f)
            {
                float direction = Mathf.Sign(transform.localScale.x);
                body.velocity = new Vector2(direction * 10f, 0f);
                body.gravityScale = 0f;
            }
            else
            {
                isDashing = false;
                body.gravityScale = 2f;
            }
        }

        if (isGroundPounding)
        {
            groundPoundTimer -= Time.deltaTime;
            if (groundPoundTimer > 0f)
            {
                body.velocity = Vector2.zero;
                body.gravityScale = 0f;
            }
            else
            {
                body.velocity = new Vector2(0f, -groundPoundForce);
                body.gravityScale = 2f;
            }
            if (IsGrounded())
            {
                isGroundPounding = false;
            }
        }

        if (isMidAirSpinning)
        {
            midAirSpinTimer -= Time.deltaTime;
            if (midAirSpinTimer > 0f)
            {
                body.velocity = new Vector2(horizontalInput * speed, 0f);
                body.gravityScale = 0f;
            }
            else
            {
                isMidAirSpinning = false;
                body.gravityScale = 2f;
            }
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x * 2, jumpPower);
        jumps--;
    }

    private void WallJump()
    {
        body.velocity = new Vector2(-wallDirX * speed, jumpPower);
        wallJumpCooldown = 0.25f;
        isWallSliding = false;
        jumps = maxJumps;
    }

    public void GroundPound()
    {
        isDashing = false;
        isMidAirSpinning = false;
        isGroundPounding = true;
        groundPoundTimer = groundPoundDelay;
        body.velocity = Vector2.zero;
    }

    public void Dash()
    {
        isGroundPounding = false;
        isMidAirSpinning = false;
        isDashing = true;
        dashTimer = dashDuration;
        dashCooldown = 0.375f;
    }

    public void MidAirSpin()
    {
        isGroundPounding = false;
        isMidAirSpinning = true;
        midAirSpinTimer = midAirSpinDuration;
        midAirSpinCooldown = 0.375f;
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, wallLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, wallLayer);

        return hitRight.collider != null || hitLeft.collider != null;
    }

    private int WallDirection()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, wallLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, wallLayer);

        if (hitRight.collider != null)
        {
            return 1;
        }
        else if (hitLeft.collider != null)
        {
            return -1;
        }

        return 0;
    }
}