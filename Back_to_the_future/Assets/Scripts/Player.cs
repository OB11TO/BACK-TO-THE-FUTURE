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

    int lives = 3;

    public float oneLifeTime = 5f;

    DragonBones.UnityArmatureComponent unityArmatureComponent;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(timeDeseaseCoroutine());

        unityArmatureComponent = GetComponentInChildren<DragonBones.UnityArmatureComponent>();
        unityArmatureComponent.animation.FadeIn("idle", 0.25f, -1);

    }

    // Update is called once per frame
    private void Update()
    {
        Flip();
        CheckGround();
        if (unityArmatureComponent.animationName != "idle")
            unityArmatureComponent.animation.FadeIn("idle", 0.25f, -1);
    }


    public void MovePlayer (float direction)
    {
        if (direction > 0.0f) isMovingForward = true;
        else isMovingForward = false;
        rb.velocity = new Vector2(direction * velocity, rb.velocity.y);
        if (unityArmatureComponent.animationName != "running")
            unityArmatureComponent.animation.FadeIn("running", 0.125f, -1);
        unityArmatureComponent.armature.flipX = isMovingForward;

    }

    public void Jump ()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            if (unityArmatureComponent.animationName != "jumping")
                unityArmatureComponent.animation.FadeIn("jumping", 0.125f, 1);
            unityArmatureComponent.armature.flipX = isMovingForward;
        }
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkGround.position, 0.2f);
        isGrounded = colliders.Length > 1;
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
}
