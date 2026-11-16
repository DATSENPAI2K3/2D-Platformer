using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] float jumpIndex = 15f;

    [SerializeField] float dashSpeed = 18f;
    [SerializeField] float dashDuration = 0.15f;
    [SerializeField] float dashCooldown = 5f;
    [Header("Dash Ghost")]
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float ghostInterval = 0.04f;
    [SerializeField] private float ghostLifetime = 0.3f;

    private Animator animator;
    private int jumpCount = 0;
    private int maxJumpCount = 2;
    private SpriteRenderer rbSprite;
    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private float facingDirection = 1f;
    private bool isDashing;
    private bool canDash = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        this.Flip();
        this.GetInput();
        this.CheckGround();
        this.Jump();
        this.Dash();
        this.UpdateAnimation();
    }
    void GetInput()
    {
        this.moveInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        this.Move();
    }
    void Move()
    {
        if (this.isDashing) return;
        rb.velocity = new Vector2(this.moveInput * this.Speed, rb.velocity.y);
    }
    void CheckGround()
    {
        this.isGrounded = Physics2D.OverlapCircle(this.groundCheck.transform.position, this.groundCheckRadius, this.groundLayer);
        if (this.isGrounded && this.rb.velocity.y <= 0f)
        {
            this.jumpCount = 0;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && this.jumpCount < this.maxJumpCount)
        {
            this.rb.velocity = new Vector2(rb.velocity.x, this.jumpIndex);
            jumpCount++;
        }
        if (Input.GetButtonUp("Jump") && this.rb.velocity.y > 0f)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, this.rb.velocity.y * 0.5f);
        }
    }
    void Flip()
    {
        if (this.moveInput < 0)
        {
            this.rbSprite.flipX = false;
            this.facingDirection = -1f;
        }
        else if (this.moveInput > 0)
        {
            this.rbSprite.flipX = true;
            this.facingDirection = 1f;
        }
    }
    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.J) && this.canDash)
        {
            StartCoroutine(DashRoutine());
        }
    }
    IEnumerator DashRoutine()
    {
        this.canDash = false;
        this.isDashing = true;
        float normalGravity = this.rb.gravityScale;
        this.rb.gravityScale = 0f;
        this.rb.velocity = new Vector2(this.facingDirection * this.dashSpeed, 0f);
        float endTime = Time.time + this.dashDuration;
        while (Time.time < endTime)
        {
            SpawnGhost();
            yield return new WaitForSeconds(this.ghostInterval);
        }

        this.rb.gravityScale = normalGravity;
        this.isDashing = false;

        yield return new WaitForSeconds(this.dashCooldown);
        this.canDash = true;
    }
    void SpawnGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        ghost.transform.localScale = transform.localScale;
        SpriteRenderer ghostSprite = ghost.GetComponent<SpriteRenderer>();
        ghostSprite.sprite = this.rbSprite.sprite;
        ghostSprite.flipX = this.rbSprite.flipX;
        Destroy(ghost, ghostLifetime);
    }
    void UpdateAnimation()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("IsGrounded", isGrounded);
    }
}
