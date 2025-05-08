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

    private Rigidbody2D body;
    private int jumps;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private bool isGroundPounding;
    private float groundPoundDelay = 0.25f;
    private float groundPoundTimer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && !isGroundPounding)
        {
            if (IsGrounded() || jumps > 0)
            {
                Jump();
            }
            else if (OnWall() && !IsGrounded())
            {
                WallJump();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && !isGroundPounding)
        {
            GroundPound();
        }
        if (IsGrounded()) jumps = maxJumps;

        if (wallJumpCooldown > 0)
        {
            wallJumpCooldown -= Time.deltaTime;
        }

        if (isGroundPounding)
        {
            groundPoundTimer -= Time.deltaTime;
            if (groundPoundTimer > 0f)
            {
                body.velocity = new Vector2(0, 0);
                body.gravityScale = 0f;
            }
            else
            {
                body.velocity = new Vector2(0, -groundPoundForce);
                body.gravityScale = 6f;
            }

        }
        else
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }


        if (IsGrounded())
        {
            if (isGroundPounding)
            {
                isGroundPounding = false;
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
        int facingDirection = (int)Mathf.Sign(transform.localScale.x);
        body.velocity = new Vector2(-facingDirection * 8f, 12f);
        wallJumpCooldown = 0.1f;
    }

    public void GroundPound()
    {
        isGroundPounding = true;
        groundPoundTimer = groundPoundDelay;
        body.velocity = Vector2.zero;
        body.gravityScale = 0;
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