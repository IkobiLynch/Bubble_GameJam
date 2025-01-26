using UnityEngine;

[RequireComponent(typeof(BaseEnemy))]
[RequireComponent(typeof(SpriteRenderer))]
public class ChasePlayer1 : MonoBehaviour
{
    private Transform player;
    private BaseEnemy baseEnemy;

    [SerializeField]
    private float chaseRange = 100f; // Distance within which the enemy starts chasing
    private float moveSpeed;

    [Header("Sprites")]
    public Sprite upSprite;     // Sprite for moving up
    public Sprite downSprite;   // Sprite for moving down
    public Sprite leftSprite;   // Sprite for moving left
    public Sprite rightSprite;  // Sprite for moving right

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        baseEnemy = GetComponent<BaseEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

            // Change sprite based on direction
            UpdateSpriteDirection(direction);
        }
    }

    private void UpdateSpriteDirection(Vector2 direction)
    {
        // Determine the primary movement direction
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Moving horizontally
            if (direction.x > 0)
                spriteRenderer.sprite = rightSprite; // Moving right
            else
                spriteRenderer.sprite = leftSprite; // Moving left
        }
        else
        {
            // Moving vertically
            if (direction.y > 0)
                spriteRenderer.sprite = upSprite; // Moving up
            else
                spriteRenderer.sprite = downSprite; // Moving down
        }
    }
}
