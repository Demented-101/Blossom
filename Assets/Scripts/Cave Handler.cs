using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CaveHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject caveCamera;
    [SerializeField] private GameObject[] geodeSpawners;
    [SerializeField] private GameObject crane;
    [SerializeField] private GameObject interactPoint;
    [SerializeField] private float interactRange;

    private bool used;

    private void Start()
    {
        caveCamera.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && Vector3.Distance(player.transform.position, interactPoint.transform.position) < interactRange && !used)
        {
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
