using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Camera_Movement class, which inherits from MonoBehaviour
public class CameraMovement : MonoBehaviour
{
    // Player reference
    public Transform player;

    // Camera movement variables
    [Range(0, 1)]
    public float smoothSpeed; // Clamped for proper interpolation
    public Vector3 offset;

    // LateUpdate is called once per frame, after all Update functions have been called
    void LateUpdate()
    {
        // Calculate the desired position of the camera based on the player's position and the offset
        Vector2 desiredPosition = new Vector2(player.position.x + offset.x, player.position.y + offset.y);
        // Smoothly interpolate between the camera's current position and the desired position
        Vector2 smoothedPosition = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), desiredPosition, smoothSpeed * Time.deltaTime);
        // Set the camera's position to the smoothed position, maintaining the original z-coordinate
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
