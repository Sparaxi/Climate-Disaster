using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
   
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        rb.AddForce(move.normalized * movementSpeed);
        


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        SpeedControl();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    private void SpeedControl() 
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatvel.magnitude > movementSpeed)
        {
            Vector3 limit = flatvel.normalized * movementSpeed;
            rb.velocity = new Vector3(limit.x, rb.velocity.y, limit.z);
        }

    }
}