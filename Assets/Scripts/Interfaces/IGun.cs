using UnityEngine;

public interface IGun
{
    void Shoot(Vector2 direction);
    string GetGunName(); // Useful for UI or debugging
}
