using UnityEngine;

[RequireComponent(typeof(BaseEnemy))]
public class ChasePlayer : MonoBehaviour
{
    private Transform player;
    private BaseEnemy baseEnemy;

    [SerializeField]
    private float chaseRange = 100f; // Distance within which the enemy starts chasing
    private float moveSpeed;
    private void Awake()
    {
        baseEnemy = GetComponent<BaseEnemy>();
        moveSpeed = baseEnemy.getMoveSpeed();
    }

    private void Start()
    {
        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
    

        // Chase the player if within range
        if (distanceToPlayer <= chaseRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
