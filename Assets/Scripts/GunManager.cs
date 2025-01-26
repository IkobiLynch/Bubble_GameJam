using UnityEngine;

public class GunManager : MonoBehaviour
{
    [Header("Gun Settings")]
    public Transform gunHolder; // Where the gun is attached to the player
    public GameObject startingGun; // Default gun to equip at the start

    public GameObject currentGun;
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

    }

    public void Start(){
        
    }

    /*public void EquipGun(Gun newGun)
    {
        if (newGun == null) return;

        // Swap gun script
        currentGun = Instantiate(newGun, gunHolder.position, gunHolder.rotation, gunHolder);

        if (gunSpriteRenderer != null)
        {
            // Swap sprite of gun. Change appearance
            currentGun.GetSpriteRenderer().sprite = newGun.GetSpriteRenderer().sprite;
        }

    } */

    public void EquipGun(GameObject newGunPrefab)
    {
        if (newGunPrefab == null) return;
        
        foreach (Transform child in gunHolder)
        {
            Destroy(child.gameObject);
        }

        // Swap gun script
        currentGun = Instantiate(newGunPrefab, gunHolder.position, gunHolder.rotation, gunHolder);

    }

    public void Shoot(Vector2 direction)
    {
        if (currentGun != null)
        {
            Gun currentGunScript = currentGun.GetComponent<Gun>();
            currentGunScript.Shoot(direction);
        }
    }
}
