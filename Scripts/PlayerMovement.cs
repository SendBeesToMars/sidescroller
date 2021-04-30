using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
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

        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(movement != Vector3.zero){
            MoveCharacter(movement);
        } else {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
        
        Vector3 horizontalMovementVector = new Vector2(movement.x * speed, rb.velocity.y);
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

    private void MoveCharacter(Vector3 movement) {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        // animator.SetFloat("speed", Mathf.Abs(direction.x) + Mathf.Abs(direction.y));

        // flips sprite depending on which way the player is heading
        if(movement.x < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if(movement.x > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        transform.position = transform.position + movement.normalized * speed * Time.deltaTime;
    }
}
