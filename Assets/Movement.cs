using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;
    public Animator Attackanimator;
    public Animator Coveranimator;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;

    [SerializeField] private float moveSpeed = 5f; // Adjust the speed as needed
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isMovingHorizontal = Mathf.Abs(horizontalInput) > 0.1f;

        // Set animation parameters based on input
        animator.SetBool("Up", verticalInput > 0);
        animator.SetBool("Down", verticalInput < 0);
        animator.SetBool("WalkSide", isMovingHorizontal || isMovingLeft || isMovingRight);

        // Flip the sprite when moving left
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            isMovingLeft = false;
            isMovingRight = true;
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
            isMovingLeft = true;
            isMovingRight = false;
        }

        // Handle character movement based on input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb2D.velocity = movement.normalized * moveSpeed;

        // Handle attacks
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            if (isMovingLeft)
            {
                animator.SetTrigger("LeftAttack"); // Trigger left attack animation
                Attackanimator.SetTrigger("LeftAttack");
                Coveranimator.SetTrigger("LeftAttack");
            }

            if (isMovingRight)
            {
                animator.SetTrigger("LeftAttack"); // Trigger left attack animation
                Attackanimator.SetTrigger("LeftAttack");
                Coveranimator.SetTrigger("LeftAttack");
            }
        }
    }
}
