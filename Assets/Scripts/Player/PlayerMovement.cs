using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            Move(input);
        }
        else
        {
            StopMoving();
        }

    }

    private void FixedUpdate() //Physics update on this function
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void Move(Vector2 input)
    {
        moveInput = input.normalized;
        animator.SetBool("IsMoving", true); //TODO: Change to non hardcoded value
        animator.SetFloat("InputX", moveInput.x); //TODO: Change to non hardcoded value
        animator.SetFloat("InputY", moveInput.y); //TODO: Change to non hardcoded value
        animator.SetFloat("LastInputX", moveInput.x); //TODO: Change to non hardcoded value
        animator.SetFloat("LastInputY", moveInput.y); //TODO: Change to non hardcoded value
    }

    private void StopMoving()
    {
        moveInput = Vector2.zero;
        animator.SetBool("IsMoving", false); //TODO: Change to non hardcoded value
    }
}
