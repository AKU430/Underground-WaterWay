using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    int move() {
        Vector3 movement = Vector3.zero;
        Vector3 velocity = rb.velocity;

        if (Input.GetKey(KeyCode.A))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            movement += Vector3.right;

        if (Input.GetKey(KeyCode.Space))
        {
            velocity += Vector3.up;
        }
        
        
        movement = movement.normalized * moveSpeed;
        
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        return 0;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void update() {
        
    }
    
    void FixedUpdate() {
        move();
    }
}
