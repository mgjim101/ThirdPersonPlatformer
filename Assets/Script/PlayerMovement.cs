using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;

    private GameObject Player;
    
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool canDoubleJump;
    private bool isDashing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = this.gameObject;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX * moveSpeed * Time.deltaTime, 0f, moveZ * moveSpeed * Time.deltaTime);

        // Jumping Logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
                canDoubleJump = true; // Allow double jump after first jump
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false; // Disable double jump after using it
            }
        }

        // Dash Logic
        if (Input.GetKeyDown(KeyCode.B) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (!isDashing) // Prevent movement changes during dash
        {
            Player.transform.position += transform.TransformDirection(moveDirection);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        Player.transform.position += transform.TransformDirection(moveDirection) * dashSpeed; // Move forward fast
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
