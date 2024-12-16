using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Enemy_Movement class, which inherits from MonoBehaviour
public class Enemy_Movement : MonoBehaviour
{
    // Declare a Transform variable to hold the player's Transform component
    public Transform player;
    // Declare a float variable to set the enemy's movement speed
    public float moveSpeed = 2f;
    // Declare a float variable to set the distance at which the enemy starts following the player
    public float followDistance = 5f;
    bool alert = false;
    public float distMult = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // Check if the distance to the player is less than the follow distance
        if (distanceToPlayer < followDistance && !alert)
        {
            followPlayer();
            alert = true;
        }else if(distanceToPlayer < followDistance * distMult && alert){
            followPlayer();
        }else{
            alert = false;
        }
        
    }
    void followPlayer(){
        // Calculate the direction from the enemy to the player and normalize it
        Vector2 direction = (player.position - transform.position).normalized;
        // Move the enemy towards the player at the specified movement speed
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}

