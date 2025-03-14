using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 이동")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    private Rigidbody2D rb;
    
    void move() {
        Vector3 movement = Vector3.zero;
        Vector3 velocity = rb.velocity;

        if (Input.GetKey(KeyCode.A))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            movement += Vector3.right;
        
        movement = movement.normalized * moveSpeed;
        
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
    
    void jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        jump();
    }
    
    void FixedUpdate() {
        move();
    }
}
