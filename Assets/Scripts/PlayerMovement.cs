using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public Camera cam;
    public Transform modelTransform;

    public float speed;
    public float jumpAmount;

    private Vector3 moveForward;
    private Vector3 moveRight;

    public bool run = true;

    public Animator anim;
    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        updateDirections();

        if (anim == null)
            Debug.LogError("Animator not found!");
        if (modelTransform == null)
            Debug.LogError("Model Transform not assigned!");
    }


    void Update()
    {
        updateDirections();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

       // Debug.Log($"Input - H: {moveHorizontal}, V: {moveVertical}");

        moveDir = (moveRight * moveHorizontal) + (moveForward * moveVertical);
        moveDir = moveDir.normalized;

        //anim.SetFloat("Speed", moveDir.magnitude);

       // Debug.Log($"Horizontal: {Input.GetAxis("Horizontal")} | Vertical: {Input.GetAxis("Vertical")}");

    }

    void FixedUpdate()
    {
        if (!run) return;

        //Debug.Log("moveDir inside FixedUpdate: " + moveDir);

        // Move the player
        Vector3 move = moveDir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Rotate model toward movement direction and play animation
        if (moveDir != Vector3.zero)
        {
            anim.SetBool("Walking", true);
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        // Jump logic
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
        if (cam == null)
        {
            Debug.LogWarning("Camera is not assigned. Skipping direction update.");
            return;
        }

        moveForward = cam.transform.forward;
        moveForward.y = 0;
        moveForward.Normalize();

        moveRight = cam.transform.right;
        moveRight.y = 0;
        moveRight.Normalize();

        // Optional: Draw debug rays
        //Debug.DrawRay(transform.position, moveForward * 2f, Color.green);
        //Debug.DrawRay(transform.position, moveRight * 2f, Color.blue);

       // Debug.Log("moveForward: " + moveForward + ", moveRight: " + moveRight);

    }
}
