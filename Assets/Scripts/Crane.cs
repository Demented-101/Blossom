using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public float speed; // use a negative number to flip movement direction
    public float maxDistance;
    public bool axisX; // when false will move on Z axis

    private float rangeMin;
    private float rangeMax;

    public bool run;

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
    }

    private void Update()
    {
        if (run){
            float movement = Input.GetAxis("Horizontal");
            Vector3 pos = transform.position;

            if (axisX)
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
        }
    }
}
