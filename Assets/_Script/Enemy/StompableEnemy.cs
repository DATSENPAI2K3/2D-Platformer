using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompableEnemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float bounceForce = 10f;
    private SpriteFlash spriteFlash;
    private EnemyPatrol patrol;
    private Collider2D enemyCollider;

    private void Awake()
    {
        enemyCollider = GetComponent<Collider2D>();
        spriteFlash = GetComponent<SpriteFlash>();
        patrol = GetComponent<EnemyPatrol>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health == null) return;

        if (IsStompedBy(other))
        {
            BouncePlayer(other);
            Die();
        }
        else
        {
            health.TakeDamage(damage);
        }
    }

    private bool IsStompedBy(Collider2D player)
    {
        return player.bounds.min.y > enemyCollider.bounds.center.y;
    }

    private void BouncePlayer(Collider2D player)
    {
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
    }

    private void Die()
    {
        enemyCollider.enabled = false;
        patrol.enabled = false;
        spriteFlash.Flash();
        Destroy(gameObject, spriteFlash.TotalDuration);
    }
}
