using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [Header("Gun Properties")]
    [SerializeField]
    public string gunName;
    [SerializeField]
    public GameObject projectilePrefab;
    [SerializeField]
    public Transform shootPoint; // Spawn point for projectiles
    [SerializeField]
    public float projectileSpeed = 10f;
    [SerializeField]
    public float fireRate = 0.5f; // Time between shots

    [SerializeField]
    protected float fireCooldownTimer = 0f;

    public virtual void Shoot(Vector2 direction)
    {
        if (fireCooldownTimer > 0) return;

        // Spawn and initialize the projectile
        if (projectilePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            projectile.GetComponent<IProjectile>()?.Initialize(direction, projectileSpeed, 10f); 
        }

        // Reset fire cooldown
        fireCooldownTimer = fireRate;
    }

    private void Update()
    {
        if (fireCooldownTimer > 0)
        {
            fireCooldownTimer -= Time.deltaTime;
        }
    }

    public string GetGunName()
    {
        return gunName;
    }
}
