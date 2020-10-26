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

    bool isNotGrounded;

    int lives = 3;

    bool isJumping = false;


    public float oneLifeTime = 15f;

    CharacterAnimation anim;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(timeDeseaseCoroutine());
        anim = transform.GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    private void Update()
    {
        Flip();

        ControlAnimation();
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
        if (isNotGrounded)
        {
            isJumping = true;
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkGround.position, 0.2f);
        isNotGrounded = colliders.Length > 1;


    }

    private void FixedUpdate()
    {
        
        if (lives == 0)
        {
            Debug.Log("Game Over!");
        }


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


    IEnumerator timeDeseaseCoroutine()
    {
        while (lives != 0)
        {
            yield return new WaitForSeconds(oneLifeTime);
            lives -= 1;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadlyObject")
        {
            Debug.Log("Ouch, hurts!");
            lives = 0;
        }
    }


    void ControlAnimation ()
    {
        if (lives == 0) anim.Die();
        else if (IsJumping()) anim.Jump();
        else if (isNotGrounded)
        {
            if (IsRunning())
            {
                anim.Run(rb.velocity.x / 4f);
            }
            else
            {
                anim.Idle();
            }
        }
    }


    bool IsRunning()
    {
        return rb.velocity.x != 0;
    }


    bool IsJumping ()
    {
        bool jumping = isJumping && isNotGrounded;
        if (!isNotGrounded) isJumping = false;
        return jumping;
    }
}
