using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    public float velocity;

    public float jumpHeight;

    private bool isMovingForward;

    public Transform checkGround;

    bool isGrounded;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Flip();
        CheckGround();
    }


    public void MovePlayer (float direction)
    {
        if (direction > 0.0f) isMovingForward = true;
        else isMovingForward = false;
        rb.velocity = new Vector2(direction * velocity, rb.velocity.y);
    }

    public void Jump ()
    {
        if (isGrounded)
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkGround.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }

    private void FixedUpdate()
    {
        

        
    }

    private void Flip()
    {
        if (isMovingForward)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
