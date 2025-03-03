using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    private GameObject Character; 
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Character = this.gameObject;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX * moveSpeed * Time.deltaTime, 0f, moveZ * moveSpeed * Time.deltaTime);
        Character.transform.position += transform.TransformDirection(moveDirection);
    }

   
}
