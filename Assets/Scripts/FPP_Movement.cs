using UnityEngine;

public class FPP_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        //// Check if the player is grounded
        //RaycastHit hitInfo;
        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 1.1f);
        Debug.Log($"isGrounded ? {isGrounded}");
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        movement = Vector3.ClampMagnitude(movement, 1f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = movement * sprintSpeed;
        }
        else
        {
            rb.velocity = movement * movementSpeed;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
