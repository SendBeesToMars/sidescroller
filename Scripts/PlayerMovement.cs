using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10;
    public float jumpForce = 5f;
    public Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    float mx;
    float my;
    bool canJump = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Vertical") && canJump){
            canJump = false;
            Vector2 jumpVector = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = jumpVector;
        }
        mx = Input.GetAxisRaw("Horizontal");
        if (mx < 0){
            spriteRenderer.flipX = true;
        }
        else if (mx > 0){
            spriteRenderer.flipX = false;
        }
        
        Vector2 horizontalMovementVector = new Vector2(mx * speed, rb.velocity.y);
        rb.velocity = horizontalMovementVector;
    }
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            canJump = true;
        }
    }
}
