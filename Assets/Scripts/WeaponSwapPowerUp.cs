using UnityEngine;

public class WeaponSwapPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private Gun newGun; // Gun to equip when this powerup is picked up

    public void Apply(GameObject player)
    {
        // Locate the GunManager on the player
        GunManager gunManager = player.GetComponentInChildren<GunManager>();
        if (gunManager != null)
        {
            gunManager.EquipGun(newGun); // Equip the new gun
        }
        Destroy(gameObject); // Destroy the powerup after applying
    }
}
