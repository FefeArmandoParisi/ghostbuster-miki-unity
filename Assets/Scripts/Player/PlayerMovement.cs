using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (LevelState.Instance.IsInputLocked)
        {
            if (LevelState.Instance.BossDefeated)
            {
                animator.SetBool(GameConstants.playerPraying, true);
                StopMoving();
                return;
            }
            else
            {
                return;
            }
        }

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
        animator.SetBool(GameConstants.playerIsMoving, true);
        animator.SetFloat(GameConstants.playerInputX, moveInput.x);
        animator.SetFloat(GameConstants.playerInputY, moveInput.y);
        animator.SetFloat(GameConstants.playerLastInputX, moveInput.x);
        animator.SetFloat(GameConstants.playerLastInputY, moveInput.y);
    }

    private void StopMoving()
    {
        moveInput = Vector2.zero;
        animator.SetBool(GameConstants.playerIsMoving, false);
    }
}
