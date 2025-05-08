using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; // Player's Rigidbody component
    public Camera cam;    // Player's Camera

    public Transform modelTransform;

    public float speed;       // Player's movement speed
    public float jumpAmount;  // Jump height

    private Vector3 moveForward; // Forward axis of the camera
    private Vector3 moveRight;   // Right axis of the camera

    public bool run = true;

    public Animator anim;
    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        updateDirections();

        if (anim == null)
        {
            Debug.LogError("Animator not found on the character.");
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDir = (moveRight * moveHorizontal) + (moveForward * moveVertical);
        moveDir = moveDir.normalized;

        anim.SetFloat("Speed", moveDir.magnitude);
    }


    void FixedUpdate()
    {
        if (!run) return;

        // Move player
        Vector3 move = moveDir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Rotate player toward movement direction
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }

        // Jump
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1.1f);
    }

    public void updateDirections()
    {
        moveForward = cam.transform.forward;
        moveForward.y = 0;
        moveForward.Normalize();

        moveRight = cam.transform.right;
        moveRight.y = 0;
        moveRight.Normalize();
    }
}
