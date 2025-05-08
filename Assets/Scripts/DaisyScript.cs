using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class DaisyScript : MonoBehaviour
{
    public Animator anim;
    public float speed = 2f;

    private Rigidbody rb;
    private Vector3 moveDir;

    string currentSceneName; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();        

        if(currentSceneName == "Forest")
        {
            GameObject constraintObject = GameObject.Find("Daisy");
            constraintObject.GetComponent<RotationConstraint>().constraintActive = false;

        }
    }

    void Update()
    {
        moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDir += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;

        moveDir = moveDir.normalized;
        anim.SetFloat("Speed", moveDir.magnitude);
    }

    void FixedUpdate()
    {
        if (moveDir != Vector3.zero)
        {
            Vector3 move = moveDir * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }
    }
}
