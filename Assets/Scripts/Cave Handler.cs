using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CaveHandler : MonoBehaviour
{
    [SerializeField] private GameObject player; // the player in the current scene
    [SerializeField] private GameObject caveCamera; // the caves camera
    [SerializeField] private GameObject[] geodeSpawners; // the geode spawners in the cave
    [SerializeField] private GameObject crane; // the crane object
    [SerializeField] private GameObject interactPoint; // the interaction point object
    [SerializeField] private float interactRange; // the range that the player can interact with the interact point object

    private bool used;

    private void Start()
    {
        caveCamera.SetActive(false); // do not overwrite player cam
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && Vector3.Distance(player.transform.position, interactPoint.transform.position) < interactRange && !used)
        { // E is pressed, player is close enough, and the cave hasnt been used
            Run();
        }
    }

    private void Run()
    {
        used = true;
        caveCamera.SetActive(true);
        interactPoint.SetActive(false);
        player.GetComponent<PlayerMovement>().cam.gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().run = false;
        crane.GetComponent<Crane>().run = true;

        foreach (GameObject obj in geodeSpawners)
        {
            obj.GetComponent<GeodeSpawner>().Run();
        }
    }

    public void End()
    {
        caveCamera.SetActive(false);
        player.GetComponent<PlayerMovement>().cam.gameObject.SetActive(true);
        player.GetComponent<PlayerMovement>().run = true;
    }
}
