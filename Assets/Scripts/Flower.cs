using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private GameObject player;
    public float pickupDistance = 2f;
    public string flowerName = "N/a";

    void Update()
    {
        player = GameObject.Find("Player");

        if (Input.GetKey(KeyCode.E) && Vector4.Distance(transform.position, player.transform.position) < pickupDistance)
        {
            if (player.GetComponent<PlayerData>().AttemptPickup(flowerName)) // add to inventory
            {
                Object.Destroy(gameObject); // destroy object
            }
        }
    }
}
