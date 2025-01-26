using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [Header("Gun Properties")]
    [SerializeField]
    public string gunName;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    public Transform shootPoint; // Spawn point for projectiles
    public float fireRate = 0.5f; // Time between shots

    [SerializeField]
    protected float fireCooldownTimer = 0f;
    
    [Header("Prefab Properties")]
    public GameObject projectilePrefab;
    [SerializeField]
    public float projectileSpeed = 10f;

    [SerializeField] private float projectileDamage = 10f;

    public void Initialize()
    {
        Transform gunImageTransform = this.transform.Find("GunImage");  
    }
    public virtual void Shoot(Vector2 direction)
    {
        if (fireCooldownTimer > 0) return;

        // Spawn and initialize the projectile
        if (projectilePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            projectile.GetComponent<IProjectile>()?.Initialize(direction, projectileSpeed, projectileDamage); 
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

    public SpriteRenderer GetSpriteRenderer(){
        return this.spriteRenderer;
    }
}
