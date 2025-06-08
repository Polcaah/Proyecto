using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 2f;
    private float jumpingPower = 5f;
    private bool isFacingRight = true;

    private bool isWallJumping;
    private bool canWallJump;
    private float wallJumpingDirection;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(3f, 6f);

    private bool playedWallJumpAnim = false;
    private bool isGrounded = false;
    private bool isTouchingWall = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                animator.Play("Player_Jump");
            }
            else if (canWallJump)
            {
                PerformWallJump();
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (isGrounded)
        {
            playedWallJumpAnim = false;

            if (Mathf.Abs(horizontal) > 0.1f)
                animator.Play("Player_Run");
            else
                animator.Play("Player_Idle");
        }
        else if (!isWallJumping)
        {
            if (isTouchingWall && !isGrounded)
            {
                animator.Play("Player_WallJump");
            }
            else if (!isTouchingWall && !isGrounded)
            {
                animator.Play("Player_Jump");
            }
        }

        if (isWallJumping && !isGrounded && !playedWallJumpAnim)
        {
            animator.Play("Player_Jump");
            playedWallJumpAnim = true;
        }

        if (!isWallJumping && !isTouchingWall)
        {
            Flip();
        }
        if (Input.GetButtonDown("PauseMenu"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void PerformWallJump()
    {
        isWallJumping = true;
        canWallJump = false;

        rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);

        if ((wallJumpingDirection > 0 && !isFacingRight) || (wallJumpingDirection < 0 && isFacingRight))
        {
            Flip();
        }

        Invoke(nameof(StopWallJumping), wallJumpingDuration);
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if ((horizontal < 0f && isFacingRight) || (horizontal > 0f && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("Wall"))
        {
            isTouchingWall = true;
            canWallJump = true;
            wallJumpingDirection = -Mathf.Sign(transform.localScale.x);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.collider.CompareTag("Wall"))
        {
            isTouchingWall = false;
            if (!isWallJumping)
            {
                canWallJump = false;
            }
        }
    }
}