using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true; // 땅에 있는지 확인
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
            isGrounded = false; // 점프하면 공중 상태로 변경
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) // "Ground" 태그와 충돌하면
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
