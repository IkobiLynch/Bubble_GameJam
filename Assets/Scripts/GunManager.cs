using UnityEngine;

public class GunManager : MonoBehaviour
{
    [Header("Gun Settings")]
    public Transform gunHolder; // Where the gun is attached to the player
    public Gun startingGun; // Default gun to equip at the start

    public Gun currentGun;
    [SerializeField] private SpriteRenderer gunSpriteRenderer;

    public void Initialize()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }

        if (gunHolder == null){
            gunHolder = transform.Find("GunHolder");
        }

        if (gunSpriteRenderer == null){
            gunSpriteRenderer = currentGun.GetSpriteRenderer();
        }
    }

    public void Start(){
        
    }

    public void EquipGun(Gun newGun)
    {
        if (newGun == null) return;

        // Swap gun script
        currentGun = Instantiate(newGun, gunHolder.position, gunHolder.rotation, gunHolder);

        if (gunSpriteRenderer != null)
        {
            // Swap sprite of gun. Change appearance
            currentGun.GetSpriteRenderer().sprite = newGun.GetSpriteRenderer().sprite;
        }

    }

    public void Shoot(Vector2 direction)
    {
        if (currentGun != null)
        {
            currentGun.Shoot(direction);
        }
    }
}
