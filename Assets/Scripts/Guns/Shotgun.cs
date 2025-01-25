using UnityEngine;

public class Shotgun : Gun
{
    public int pelletCount = 5;

    public override void Shoot(Vector2 direction)
    {
        if (fireCooldownTimer > 0) return;

        for (int i = 0; i < pelletCount; i++)
        {
            Vector2 spread = direction + new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            base.Shoot(spread);
        }

        fireCooldownTimer = fireRate;
    }
}