using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; // players rigidbody component
    public Camera cam; // player camera

    public float speed; // players speed
    public float jumpAmount; // jump height

    private Vector3 moveForward; // the forward and right axis of the camera
    private Vector3 moveRight; // used to orient the players movement with the camera

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveForward = cam.transform.forward;
        moveForward.y = 0; // remove the y component to make sure player doent move down

        moveRight = cam.transform.right;
        moveRight.y = 0;
    }

    void FixedUpdate() //code for WASD and space key movement
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (moveRight * moveHorizontal) + (moveForward * moveVertical);

        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime); 

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpAmount, ForceMode.Impulse); 
        }

    }

}