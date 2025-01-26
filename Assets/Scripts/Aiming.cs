using UnityEngine;
using UnityEngine.InputSystem;
public class Aiming : MonoBehaviour
{
    private PlayerControls controls; // Input system reference
    private Vector2 shootDirection;

    [Header("Gun System")]
    public GunManager gunManager; // Gun manager to handle shooting

    [SerializeField] private Transform gunTransform;

    private Camera theCam;

    private Vector2 bulletOffset;
    private void Awake()
    {
        controls = new PlayerControls();

        // Initialize the GunManager with the default gun
        if (gunManager != null)
        {
            gunManager.Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* // Continuously rotate the gun to face the mouse position
        if (gunTransform != null)
        {
            RotateGunTowardsMouse();
        } */
    }

    private void OnEnable()
    {
        // Enable input actions
        controls.Player.Enable();

        // Bind actions to the methods
        controls.Player.Shoot.performed += OnShoot;
        controls.Player.Aim.performed += OnAim;
    }

    private void OnDisable()
    {
        // Disable input actions
        controls.Player.Disable();

        // Unbind actions to prevent memory leaks
        controls.Player.Shoot.performed -= OnShoot;
        controls.Player.Aim.performed -= OnAim;
    }

    // Called by the Input System when the "Shoot" action is performed
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && gunManager != null)
        {
            gunManager.Shoot(bulletOffset);
        }
    }

    // Called by the Input System when the "Aim" action is performed
    public void OnAim(InputAction.CallbackContext context)
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Mouse.current.position.ReadValue();

        // Calculate the direction to the mouse
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.localPosition);
        //Debug.Log($"Direction is {direction}, MousePosition is {mousePosition}");
        // Calculate the angle to rotate
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        bulletOffset = offset;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }

    private void RotateGunTowardsMouse()
    {
       // Get the mouse position in world space
        Vector3 mousePosition = Mouse.current.position.ReadValue();

        // Calculate the direction to the mouse
        Vector3 screenPoint = theCam.WorldToScreenPoint(this.transform.localPosition);
        //Debug.Log($"Direction is {direction}, MousePosition is {mousePosition}");
        // Calculate the angle to rotate
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        bulletOffset = offset;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
