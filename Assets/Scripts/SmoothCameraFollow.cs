using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player; // Reference to the player's transform
    [SerializeField]
    private float smoothSpeed = 0.125f; // Speed of the camera's smoothing
    [SerializeField]
    private Vector3 offset; // Offset to maintain distance from the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Desired camera position with offset
            Vector3 desiredPosition = player.position + offset;

            // Smoothly interpolate between current and desired positions
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
