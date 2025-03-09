using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private GameObject player;
    public float pickupDistance = 2f;
    public string flowerName = "N/a";
    public bool doPickup = false;

    [Header("parts")]
    [SerializeField] private GameObject flowerObj;
    [SerializeField] private GameObject stemObj;

    [Header("Materials")]
    [SerializeField] private Material flowerMaterial;
    [SerializeField] private Material stemMaterial;

    void Update()
    {
        player = GameObject.Find("Player");

        if (doPickup && Input.GetKey(KeyCode.E) && Vector4.Distance(transform.position, player.transform.position) < pickupDistance)
        {
            if (player.GetComponent<PlayerData>().AttemptPickup(flowerName)) // add to inventory
            {
                Object.Destroy(gameObject); // destroy object
            }
        }
    }
}
