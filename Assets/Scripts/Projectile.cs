using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    private Vector2 direction;
    private float speed;
    private float damage;

    public void Initialize(Vector2 direction, float speed, float damage)
    {
        this.direction = direction.normalized;
        this.speed = speed;
        this.damage = damage;
    }

    private void Update()
    {
        // Move the projectile in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object hit is damageable
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        // Destroy the projectile after collision
        Destroy(gameObject);
    }
}
