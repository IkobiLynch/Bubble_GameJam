using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed =5f; 
    [SerializeField]
    private float dashSpeed = 20f;
    [SerializeField]
    private float dashDuration = 0.2f; // Duration of dash
    [SerializeField]
    private float dashCooldown = 0f; // Time between dashes

    private Vector2 movementInput; // Store movement input
    private Rigidbody2D rb; //rigidbody reference

    private PlayerControls controls; // Input system reference

    private bool isDashing = false; // Tracks if the player is dashing
    private float dashCooldownTimer = 0f; // Timer for dash cooldown
    private void Awake(){
        //Initialzie Input
        controls = new PlayerControls();

        //Get rigidbody2d 
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Enable the Player action map
        controls.Player.Enable();

        // Subscribe to the Move action
        controls.Player.Move.performed += OnMoveInput;
        controls.Player.Move.canceled += OnMoveInput;
        controls.Player.Dash.performed += OnDashInput;
    }

    private void OnDisable()
    {
        // Disable the Player action map
        controls.Player.Disable();

        // Unsubscribe from the Move action
        controls.Player.Move.performed -= OnMoveInput;
        controls.Player.Move.canceled -= OnMoveInput;
        controls.Player.Dash.performed -= OnDashInput;
    }

    private void FixedUpdate()
    {
        // Handle regular movement
        if (!isDashing)
        {
            rb.linearVelocity = movementInput * speed;
        }

        // Decrease the dash cooldown timer
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.fixedDeltaTime;
        }
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        // Read movement input (Vector2)
        movementInput = context.ReadValue<Vector2>();
    }
    
    private void OnDashInput(InputAction.CallbackContext context)
    {
        // Perform a dash if not already dashing and cooldown is complete
        if (!isDashing && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        Vector2 dashDirection = movementInput.normalized;

        // Apply dash velocity
        rb.linearVelocity = dashDirection * dashSpeed;

        // Wait for the dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset velocity to stop dashing
        rb.linearVelocity = Vector2.zero;

        // Start cooldown
        isDashing = false;
        dashCooldownTimer = dashCooldown;
    }

}
