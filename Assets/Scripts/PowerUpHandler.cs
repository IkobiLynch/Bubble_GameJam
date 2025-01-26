using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has a component that implements IPowerUp
        IPowerUp powerUp = collision.GetComponent<IPowerUp>();
        Debug.Log("Collision occured");
        if (powerUp != null)
        {
            // Apply the powerup to the player
            powerUp.Apply(this.gameObject);
        }
    }
}
