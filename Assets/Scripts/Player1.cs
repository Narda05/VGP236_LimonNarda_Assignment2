using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumForce = 500;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
    [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode jumpKeyCode = KeyCode.W;

    private bool canJump = true;
    float horizontalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("DirectionPlayer1", 1.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKeyCode) && canJump)
        {
            rb.AddForce(new Vector2(0, jumForce));
            canJump = false;
            animator.SetBool("IsJumpingPlayer1", true);
        }

        horizontalMovement = 0.0f;
        if (Input.GetKey(rightKeyCode))
        {
            horizontalMovement += 1.0f;
        }
        else if (Input.GetKey(leftKeyCode))
        {
            horizontalMovement -= 1.0f;
        }

        horizontalMovement *= speed;

        if (horizontalMovement < 0)
        {
            animator.SetFloat("DirectionPlayer1", -1.0f);
        }
        else if (horizontalMovement > 0)
        {
            animator.SetFloat("DirectionPlayer1", 1.0f);
        }

        animator.SetFloat("SpeedPlayer1", Mathf.Abs(horizontalMovement));
        animator.SetBool("IsFalling", (rb.linearVelocityY < -0.01f));
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement, rb.linearVelocityY);
    }

    public void LandedOnground()
    {
        animator.SetBool("IsJumpingPlayer1", false);
        animator.SetBool("IsFalling", false);
        canJump = true;
    }
}
