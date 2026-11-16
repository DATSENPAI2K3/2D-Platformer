using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float bounceForce = 0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        this.BouncePlayer(other);
    }
    private void BouncePlayer(Collider2D player)
    {
        if (this.bounceForce <= 0f) return;
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(playerRb.velocity.x, this.bounceForce);
    }
}
