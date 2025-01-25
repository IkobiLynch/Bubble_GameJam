using UnityEngine;

[RequireComponent(typeof(BaseEnemy))]
public class EnemyAttack : MonoBehaviour, IAttack
{
    [SerializeField]
    private float attackRange = 0.5f; // Distance within which the enemy can attack
    [SerializeField]
    private float attackDamage = 10f;
    [SerializeField]
    private float attackCooldown = 1f; // Time between attacks

    private Transform player;
    private float attackCooldownTimer = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;

        attackCooldownTimer -= Time.deltaTime;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Attack the player if within range and cooldown has elapsed
        if (distanceToPlayer <= attackRange && attackCooldownTimer <= 0f)
        {
            Attack();
            attackCooldownTimer = attackCooldown;
        }
    }

    public void Attack()
    {
        Debug.Log($"{gameObject.name} attacks the player for {attackDamage} damage!");
        // Assuming the player has an IDamageable interface
        IDamageable damageable = player.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(attackDamage);
        }
    }
}
