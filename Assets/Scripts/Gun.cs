using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [Header("Gun Properties")]
    [SerializeField] public string gunName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public Transform shootPoint; // Spawn point for projectiles
    public float fireRate = 0.5f; // Time between shots

    [SerializeField] protected float fireCooldownTimer = 0f;

    [Header("Prefab Properties")]
    public GameObject projectilePrefab;
    [SerializeField] public float projectileSpeed = 10f;
    [SerializeField] private float projectileDamage = 10f;

    [Header("Audio Properties")]
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip shootSound; // Audio clip for shooting

    public void Initialize()
    {
        // Optionally find and cache child components if needed
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

        // Play the shooting sound
        PlayShootSound();

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

    public SpriteRenderer GetSpriteRenderer()
    {
        return this.spriteRenderer;
    }

    private void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
