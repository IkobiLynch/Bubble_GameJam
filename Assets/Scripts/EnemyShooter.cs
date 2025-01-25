using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Gun gunPrefab;
    private Gun equippedGun;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Equip the gun
        if (gunPrefab != null)
        {
            equippedGun = Instantiate(gunPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        if (player == null || equippedGun == null) return;

        // Aim at the player and shoot
        Vector2 direction = (player.position - equippedGun.transform.position).normalized;
        equippedGun.Shoot(direction);
    }
}
