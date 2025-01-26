using UnityEngine;

public class WeaponSwapPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private GameObject newGunPrefab; // Gun to equip when this powerup is picked up

    public void Apply(GameObject player)
    {
        // Locate the GunManager on the player
        GunManager gunManager = player.GetComponentInChildren<GunManager>();
        Debug.Log($"Swap gun to {newGunPrefab}");
        if (gunManager != null)
        {
            gunManager.EquipGun(newGunPrefab); // Equip the new gun
        }
        Destroy(gameObject); // Destroy the powerup after applying
    }
}
