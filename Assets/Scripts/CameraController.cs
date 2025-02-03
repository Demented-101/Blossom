using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement player;

    public bool allowRotation = true;
    public float startRotation = 45;

    private bool moving;
    private float targetRotation;
    private float moveTime;

    private void Start(){
        transform.eulerAngles = new Vector3(0,startRotation,0); // sets the camera's rotation to the start rotation
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !moving && allowRotation)
        {
            moving = true;
            moveTime = 0.0f; // begins "timer"
            targetRotation = transform.eulerAngles.y + 90;
        }

        if (moving)
        {
            transform.Rotate(Vector3.up, 180 * Time.deltaTime); // changes rotation
            moveTime += Time.deltaTime;
            player.updateDirections();
            if(moveTime >= 0.5f) // if timer complete
            {
                moving = false;
                transform.eulerAngles = new Vector3(0, targetRotation, 0); // set rotation directly, stops any incorrect rotations.
            }
        }
    }
}
