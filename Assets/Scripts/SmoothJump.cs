using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmoothJump : MonoBehaviour
{
    public float fallMultiplyer = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;
        }
    }
}
