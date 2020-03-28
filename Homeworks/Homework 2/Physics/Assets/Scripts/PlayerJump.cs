using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField]
    private float force = 2;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = true;
        } 
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded)
        {
            body.useGravity = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
        body.useGravity = true;
    }
}
