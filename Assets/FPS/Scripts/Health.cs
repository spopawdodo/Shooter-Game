using UnityEngine;
using UnityEngine.Events;
using System;
using System.Reflection;

public class Health : MonoBehaviour
{
    [Tooltip("Maximum amount of health")]
    public float maxHealth = 10f;
    [Tooltip("Health ratio at which the critical health vignette starts appearing")]
    public float criticalHealthRatio = 0.3f;

    public UnityAction<float, GameObject> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;

    public float currentHealth { get; set; }
    public bool invincible { get; set; }
    public bool canPickup() => currentHealth < maxHealth;

    public float getRatio() => currentHealth / maxHealth;
    public bool isCritical() => getRatio() <= criticalHealthRatio;

    bool m_IsDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // call OnHeal action
        float trueHealAmount = currentHealth - healthBefore;

        if (gameObject.CompareTag("Player"))
        {
            PlayerScore player = FindObjectOfType<PlayerScore>();
            player.AddPoints(5);
            print("Player healed" + player.currentPoints);
        }
        if (trueHealAmount > 0f && onHealed != null)
        {
            onHealed.Invoke(trueHealAmount);
        }
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        if (invincible)
            return;

        if (gameObject.CompareTag("Enemy"))
        {
            PlayerScore player = FindObjectOfType<PlayerScore>();
            player.AddPoints(5);
            print("Enemy attacked" + player.currentPoints);
        }

        float healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // call OnDamage action
        float trueDamageAmount = healthBefore - currentHealth;
        if (trueDamageAmount > 0f && onDamaged != null)
        {
            onDamaged.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }

    public void Kill()
    {
        currentHealth = 0f;
        // call OnDamage action
        if (onDamaged != null)
        {
            onDamaged.Invoke(maxHealth, null);
        }

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        if (currentHealth <= 0f)
        {
            if (onDie != null)
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    PlayerScore player = FindObjectOfType<PlayerScore>();
                    player.AddPoints(30);
                    //print("Enemy killed " + player.currentPoints);
                }

                if (gameObject.CompareTag("Player"))
                {
                    PlayerScore player = FindObjectOfType<PlayerScore>();
                    player.DecreasePoints(30);
                   // print("Player died" + player.currentPoints);
                    player.UpdateHighScore();
                }
                m_IsDead = true;
                onDie.Invoke();
            }
        }
    }
}
