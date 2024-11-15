using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement player;

    private bool moving;
    private float targetRotation;
    private float moveTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !moving)
        {
            moving = true;
            moveTime = 0.0f;
            targetRotation = transform.eulerAngles.y + 90;
        }

        if (moving)
        {
            transform.Rotate(Vector3.up, 180 * Time.deltaTime);
            moveTime += Time.deltaTime;
            player.updateDirections();
            if(moveTime >= 0.5f)
            {
                moving = false;
                transform.eulerAngles = new Vector3(0, targetRotation, 0);
            }
        }
    }
}
