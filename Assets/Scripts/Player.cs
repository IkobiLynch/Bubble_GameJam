using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour, IDamageable
{
    [Header("Health Settings")]
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;

    [Header("Gun System")]
    public GunManager gunManager;
    private Vector2 shootDirection;
    private void Awake()
    {
        currentHealth = maxHealth;

        // Initialize the GunManager with the default gun
        if (gunManager != null)
        {
            gunManager.Initialize();
        }
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

    // Called by the Input System when the "Shoot" action is performed
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && gunManager != null)
        {
            gunManager.Shoot(shootDirection);
        }
    }

    // Called by the Input System when the "Aim" action is performed
    public void OnAim(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        shootDirection = (mousePosition - (Vector2)transform.position).normalized;
    }
}
