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
    private bool isShooting = false; // Tracks if the shoot button is being held

    private void Awake()
    {
        controls = new PlayerControls();

        // Initialize the GunManager with the default gun
        if (gunManager != null)
        {
            gunManager.Initialize();
        }

        // Cache the main camera reference
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously handle shooting if the button is held
        if (isShooting && gunManager != null)
        {
            gunManager.Shoot(bulletOffset);
        }
    }

    private void OnEnable()
    {
        // Enable input actions
        controls.Player.Enable();

        // Bind actions to the methods
        controls.Player.Shoot.performed += OnShoot;
        controls.Player.Shoot.canceled += OnShootRelease; // Detect when button is released
        controls.Player.Aim.performed += OnAim;
    }

    private void OnDisable()
    {
        // Disable input actions
        controls.Player.Disable();

        // Unbind actions to prevent memory leaks
        controls.Player.Shoot.performed -= OnShoot;
        controls.Player.Shoot.canceled -= OnShootRelease;
        controls.Player.Aim.performed -= OnAim;
    }

    // Called by the Input System when the "Shoot" action is performed
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isShooting = true; // Start shooting when button is pressed
        }
    }

    // Called by the Input System when the "Shoot" action is canceled (button released)
    public void OnShootRelease(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isShooting = false; // Stop shooting when button is released
        }
    }

    // Called by the Input System when the "Aim" action is performed
    public void OnAim(InputAction.CallbackContext context)
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Mouse.current.position.ReadValue();

        // Calculate the direction to the mouse
        Vector3 screenPoint = theCam.WorldToScreenPoint(this.transform.position);
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        bulletOffset = offset.normalized; // Normalize the offset for shooting direction
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
