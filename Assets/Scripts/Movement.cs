using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public float speed =5f; 
    private Vector2 movementInput;
    private Rigidbody2D rb;

    private PlayerControls controls;

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
    }

    private void OnDisable()
    {
        // Disable the Player action map
        controls.Player.Disable();

        // Unsubscribe from the Move action
        controls.Player.Move.performed -= OnMoveInput;
        controls.Player.Move.canceled -= OnMoveInput;
    }

    private void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        rb.linearVelocity = movementInput * speed;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        // Read movement input (Vector2)
        movementInput = context.ReadValue<Vector2>();
    }
    

}
