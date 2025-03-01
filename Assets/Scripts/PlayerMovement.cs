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
        updateDirections();
    }

    void FixedUpdate() //code for WASD and space key movement
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (moveRight * moveHorizontal) + (moveForward * moveVertical);

        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime); 
        if(Input.GetKey(KeyCode.Space) && isGrounded()) // check player can jump/stop flying
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpAmount, ForceMode.Impulse);
        }

    }

    public bool isGrounded()  {return Physics.Raycast(transform.position, -Vector3.up, 1.1f); }

    public void updateDirections()
    {
        moveForward = cam.transform.forward;
        moveForward.y = 0; // remove the y component to make sure player doent move down

        moveRight = cam.transform.right;
        moveRight.y = 0;
    }
}