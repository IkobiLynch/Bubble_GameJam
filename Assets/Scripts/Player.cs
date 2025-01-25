using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Remaining health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player has died!");
        // Add respawn or game over logic here
    }
}
