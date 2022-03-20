using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public KeyCode jumpKeyCode;
    public float jumpSpeed = 5f;
    public int defaultJumpAllowed = 1;
    int jumpAllowed;
    Rigidbody rb;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpAllowed = defaultJumpAllowed;        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(jumpKeyCode))
        {
            if (isGrounded)
            {
                Jump();
                isGrounded = false;
            }
            else if (!isGrounded && jumpAllowed > 0)
            {
                Jump();
                jumpAllowed--;
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpAllowed = defaultJumpAllowed;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;

        }
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpSpeed, ForceMode.VelocityChange);
    }
}
