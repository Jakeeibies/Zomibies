using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Enemy_Movement class, which inherits from MonoBehaviour
public class EnemyMovement : MonoBehaviour
{
    // Player reference
    public Transform player;

    // Movement variables
    public float moveSpeed = 2f;
    public float followDistance = 5f;
    public float distMult = 1.5f;
    bool alert = false;
    float previousSpeed;

    // Separation variables
    public float separationDistance = 1f; // Minimum distance between enemies
    public float separationForce = 1f; // Force to apply for separation

    // Components
    Rigidbody2D rb;

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

        // Apply separation force to prevent overlapping with other enemies
        ApplySeparationForce();
    }

    void followPlayer()
    {
        // Calculate the direction from the enemy to the player and normalize it
        Vector2 direction = (player.position - transform.position).normalized;
        // Move the enemy towards the player at the specified movement speed
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void ApplySeparationForce()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, separationDistance);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Enemy"))
            {
                Vector2 direction = (transform.position - collider.transform.position).normalized;
                rb.AddForce(direction * separationForce);
            }
        }
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

