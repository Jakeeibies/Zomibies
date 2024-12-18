using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Components
    Rigidbody2D rb;

    // Push force variable
    public float pushForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Reg Zom"))
        {
            col.gameObject.GetComponent<EnemyMovement>().InvokeStop();
            gameObject.GetComponent<PlayerMovement>().stopMovement();
            Vector2 pushDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(pushDirection * (pushForce * 100)); // Adjust the force value as needed
        }
    }
}
