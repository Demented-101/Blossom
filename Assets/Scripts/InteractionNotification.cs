using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionNotification : MonoBehaviour
{
    public string displayText = "TEXT";
    public float range = 1f;
    public float textSize = 36f;

    private GameObject textObj;
    private GameObject player;

    private void Start()
    {
        textObj = transform.GetChild(0).gameObject;
        textObj.GetComponent<TextMeshPro>().text = displayText;
        textObj.GetComponent<TextMeshPro>().fontSize = textSize;
        textObj.SetActive(false);

        player = GameObject.Find("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        textObj.SetActive(distance <= range);
        transform.LookAt(player.GetComponent<PlayerMovement>().cam.transform.position); // this will get the camera's position
    }
}
