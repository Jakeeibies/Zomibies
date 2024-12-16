using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Player_Movement class, which inherits from MonoBehaviour
public class Player_Movement : MonoBehaviour
{
    // Declare a Rigidbody2D variable to hold the player's Rigidbody2D component
    Rigidbody2D rb;
    // Declare a float variable to set the player's movement speed
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player and assign it to the rb variable
        rb = GetComponent<Rigidbody2D>();
        // Disable gravity for the player's Rigidbody2D component
        rb.gravityScale = 0;
    }

    // FixedUpdate is called at a fixed interval and is used for physics updates
    void FixedUpdate()
    {
        // Get the horizontal input (A/D or Left/Right arrow keys) and store it in moveX
        float moveX = Input.GetAxisRaw("Horizontal");
        // Get the vertical input (W/S or Up/Down arrow keys) and store it in moveY
        float moveY = Input.GetAxisRaw("Vertical");
        // Create a new Vector2 for the movement direction based on moveX and moveY
        Vector2 movement = new Vector2(moveX, moveY);
        // Set the player's velocity to the movement direction multiplied by the movement speed
        rb.velocity = movement * moveSpeed;
    }
}