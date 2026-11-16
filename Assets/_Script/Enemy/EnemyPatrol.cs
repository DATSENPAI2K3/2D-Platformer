using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection = Vector2.right;
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 0.5f;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 target;
    private float waitTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pointA = transform.position;
        pointB = pointA + moveDirection.normalized * moveDistance;
        target = pointB;
        FaceTarget();
    }

    private void FixedUpdate()
    {
        Patrol();
        UpdateAnimation();
    }

    private void Patrol()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.fixedDeltaTime;
            return;
        }
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
        if (Vector2.Distance(newPosition, target) < 0.01f)
        {
            target = (target == pointB) ? pointA : pointB;
            waitTimer = waitTime;
            FaceTarget();
        }
    }

    private void FaceTarget()
    {
        if (moveDirection.x == 0f) return;
        sr.flipX = target.x > transform.position.x;
    }
    private void UpdateAnimation()
    {
        if (animator == null) return;
        animator.SetBool("IsMoving", waitTimer <= 0f);
    }
}
