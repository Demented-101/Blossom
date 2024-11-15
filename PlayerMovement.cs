using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class PlayerMovement : MonoBehaviour
{
    private RibidBody rb; //this is private as you are directly attaching the script onto the player
                          //instead of declaring a GameObject and assigning the player in the inspector. 
                          //Unity will automatically find the rigidbody attached to the player
                          //so make sure the player has a rigidbody

    void FixedUpdate() //code for WASD and space key movement
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * moveHorizontal) + (transform.forward * moveVertical);

        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime); 

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpAmount, ForceMode.Impulse); 
        }

    }

}