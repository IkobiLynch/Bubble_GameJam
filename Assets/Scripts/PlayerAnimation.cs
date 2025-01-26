using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Sprite[] sprites; // Array to hold four sprites (up, down, left, right) in order
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure a default sprite is set if not already assigned
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[0]; // Set default sprite (e.g., down)
        }
    }

    void Update()
    {
        // Check for arrow key presses and change the sprite accordingly
        if (Input.GetKeyDown(KeyCode.UpArrow) && sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[0]; // Up sprite
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && sprites.Length > 1)
        {
            spriteRenderer.sprite = sprites[1]; // Down sprite
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && sprites.Length > 2)
        {
            spriteRenderer.sprite = sprites[2]; // Left sprite
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && sprites.Length > 3)
        {
            spriteRenderer.sprite = sprites[3]; // Right sprite
        }
    }
}
