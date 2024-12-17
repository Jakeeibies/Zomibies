using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Enemy_Movement class, which inherits from MonoBehaviour
public class Enemy_Movement : MonoBehaviour
{
    public Transform player;
    Rigidbody2D rb;
    public float moveSpeed = 2f;
    public float followDistance = 5f;
    bool alert = false;
    public float distMult = 1.5f;
    float previousSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

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
        }
        else if (distanceToPlayer < followDistance * distMult && alert)
        {
            followPlayer();
        }
        else
        {
            alert = false;
        }
        Debug.Log(moveSpeed);
    }

    void followPlayer()
    {
        // Calculate the direction from the enemy to the player and normalize it
        Vector2 direction = (player.position - transform.position).normalized;
        // Move the enemy towards the player at the specified movement speed
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    public void InvokeStop()
    {
        StopAllCoroutines();
        previousSpeed = moveSpeed;
        moveSpeed = 0;
        StartCoroutine(RestoreMovement());
    }

    IEnumerator RestoreMovement()
    {
        yield return new WaitForSeconds(1.5f);
        moveSpeed = previousSpeed;
    }

    
}

