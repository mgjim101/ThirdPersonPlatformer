using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;  // Player's transform
    public float distance = 5f;
    public float smoothSpeed = 10f;
    public float rotationSpeed = 2f;
    
    private float mouseX;

    private float mouseY;

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * 10;
        mouseY = Mathf.Clamp(mouseY, -60, 60f); // Limit camera tilt

        player.transform.Rotate(0,mouseX * rotationSpeed * Time.deltaTime, 0);
        this.transform.localEulerAngles = new Vector3 (mouseY,0,0);
    }
}
