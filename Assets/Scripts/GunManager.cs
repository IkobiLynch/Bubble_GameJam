using UnityEngine;

public class GunManager : MonoBehaviour
{
    [Header("Gun Settings")]
    public Transform gunHolder; // Where the gun is attached to the player
    public Gun startingGun; // Default gun to equip at the start

    private Gun currentGun;

    public void Initialize()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun newGun)
    {
        if (currentGun != null)
        {
            Destroy(currentGun.gameObject); // Remove the old gun
        }

        currentGun = Instantiate(newGun, gunHolder.position, gunHolder.rotation, gunHolder);
    }

    public void Shoot(Vector2 direction)
    {
        if (currentGun != null)
        {
            currentGun.Shoot(direction);
        }
    }
}
