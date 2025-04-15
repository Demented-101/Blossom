using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public GameObject caveHandler;

    public float speed; // use a negative number to flip movement direction
    public float maxDistance;
    public bool axisX; // when false will move on Z axis

    private float rangeMin;
    private float rangeMax;

    public bool run;

    public GameObject craneArm;
    public bool runArm = false;
    public float armSpeed = 2;
    private bool armState = false;
    private float armStartY;

    private void Start()
    {
        if (axisX)
        {
            rangeMax = transform.position.x + maxDistance;
            rangeMin = transform.position.x - maxDistance;
        }
        else
        {
            rangeMax = transform.position.z + maxDistance;
            rangeMin = transform.position.z - maxDistance;
        }

        Vector3 armPos = craneArm.transform.position;
        armStartY = armPos.y;
    }

    private void Update()
    {
        if (run){
            if (runArm) // arm move up and down
            {
                Vector3 armPos = craneArm.transform.position;
                if (!armState)
                {
                    armPos.y -= armSpeed * Time.deltaTime;
                }
                else
                {
                    armPos.y += armSpeed * Time.deltaTime * 1.3f;
                }
                armPos.y = Mathf.Clamp(armPos.y, armStartY - 6, armStartY);
                craneArm.transform.position = armPos;

                if (armPos.y <= armStartY - 5.95) { PickUp(); }

                if (armPos.y >= armStartY - 0.05 && armState) { End(); }
            }
            else
            {
                float movement = Input.GetAxis("Horizontal");
                Vector3 pos = transform.position;

                if (axisX) // move left + right with arm
                {
                    pos.x += speed * movement * Time.fixedDeltaTime;
                    if (pos.x > rangeMax) { pos.x = rangeMax; }
                    else if (pos.x < rangeMin) { pos.x = rangeMin; }
                }
                else
                {
                    pos.z += speed * movement * Time.fixedDeltaTime;
                    if (pos.z > rangeMax) { pos.z = rangeMax; }
                    else if (pos.z < rangeMin) { pos.z = rangeMin; }
                }

                transform.position = pos;

                if (Input.GetKeyDown("space"))
                {
                    runArm = true;
                }
            }
        }
    }
    
    private void End()
    {
        run = false;
        caveHandler.GetComponent<CaveHandler>().End();
    }

    private void PickUp()
    {
        armState = true;

        RaycastHit ray;
        bool hit;
        hit = Physics.Raycast(craneArm.transform.position, Vector3.down, out ray, Mathf.Infinity);
        if (hit)
        {
            GameObject geodeObj = ray.collider.gameObject; // get the geode collided with
            string geodeName = geodeObj.GetComponent<Geode>().geodeName; // get the name of the geode
            caveHandler.GetComponent<PlayerData>().AttemptPickup(geodeName); // add geode to inventory
        }
    }
}
