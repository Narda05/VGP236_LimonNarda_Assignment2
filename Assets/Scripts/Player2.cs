using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumForce = 500;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
    [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode jumpKeyCode = KeyCode.W;
    [SerializeField] private KeyCode placeBoxKey = KeyCode.E; 

    [SerializeField] private GameObject boxPrefab;  
    private bool canPlaceBox = true;  

    private bool canJump = true;
    private float horizontalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("DirectionPlayer2", 1.0f);
    }

    void Update()
    {
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
            animator.SetFloat("DirectionPlayer2", -1.0f);
        }
        else if (horizontalMovement > 0)
        {
            animator.SetFloat("DirectionPlayer2", 1.0f);
        }

        animator.SetFloat("SpeedPlayer2", Mathf.Abs(horizontalMovement));
        animator.SetBool("IsFalling", (rb.linearVelocity.y < -0.01f));

        if (canPlaceBox && Input.GetKeyDown(placeBoxKey))
        {
            PlaceBox();
        }

        if (Input.GetKeyDown(jumpKeyCode) && canJump)
        {
            rb.AddForce(new Vector2(0, jumForce));
            canJump = false;
            animator.SetBool("IsJumpingPlayer2", true);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement, rb.linearVelocity.y);  
    }

    public void LandedOnground()
    {
        animator.SetBool("IsJumpingPlayer2", false);
        animator.SetBool("IsFalling", false);
        canJump = true;
    }

   
    private void PlaceBox()
    {
       
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

        
        GameObject newBox = Instantiate(boxPrefab, mousePosition, Quaternion.identity);

        newBox.tag = "BoxPlayer2";
    }
}
