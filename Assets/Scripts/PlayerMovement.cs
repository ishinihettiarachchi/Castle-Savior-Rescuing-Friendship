using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableGround;
    

    private float directionX = 0f;
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float moveSpped = 7f;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector3(directionX * moveSpped, rigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("Jumping!");

            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed);
        }

        AnimationUpdate();
    }
 
        private void AnimationUpdate()
        {
            if (directionX > 0f)
            {

                rigidBody.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                animator.SetBool("isRunning", true);
                
                
            }
            else if (directionX < 0f)
            {
                rigidBody.transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
                animator.SetBool("isRunning", true);
                
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }


    
}
