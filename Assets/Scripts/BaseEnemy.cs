using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float maxHealth = 100f;
    private float currentHealth;

    [SerializeField]
    private float moveSpeed = 3f; // Movement speed
    
    public Transform player;    // Reference to the player

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        Destroy(gameObject); // Destroy the enemy
    }

    public float getMoveSpeed(){
        return this.moveSpeed;
    }
}
