using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 6;
    [SerializeField] private float invincibleTime = 1f;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private EndScreen EndScreen;
    private static int savedHealth = -1;
    private SpriteFlash spriteFlash;
    private int currentHealth;
    private float invincibleTimer;
    private void Awake()
    {
        currentHealth = (savedHealth >= 0) ? savedHealth : maxHealth;
        spriteFlash = GetComponent<SpriteFlash>();
    }
    private void Start()
    {
        healthUI.UpdateHearts(currentHealth);
    }
    private void Update()
    {
        if (invincibleTimer > 0f) invincibleTimer -= Time.deltaTime;
    }
    public void TakeDamage(int amount)
    {
        if (invincibleTimer > 0f) return;
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        savedHealth = currentHealth;
        invincibleTimer = invincibleTime;
        healthUI.UpdateHearts(currentHealth);
        spriteFlash.Flash();
        if (currentHealth == 0) Die();
    }
    public bool Heal(int amount)
    {
        if (currentHealth >= maxHealth) return false;
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        savedHealth = currentHealth;
        healthUI.UpdateHearts(currentHealth);
        return true;
    }
    public static void ResetSavedHealth()
    {
        savedHealth = -1;
    }
    private void Die()
    {
        this.EndScreen.ShowLose();
    }
}
