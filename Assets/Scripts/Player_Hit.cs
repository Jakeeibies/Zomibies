using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit : MonoBehaviour
{
    Rigidbody2D rb;
    public float pushForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Reg Zom"))
        {
            col.gameObject.GetComponent<Enemy_Movement>().InvokeStop();
            gameObject.GetComponent<Player_Movement>().stopMovement();
            Vector2 pushDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(pushDirection * (pushForce*100)); // Adjust the force value as needed
        }
    }
}
