using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractLabel : MonoBehaviour
{
    public string text;
    public float distance;
    public float size;

    private void Start() {
        UpdateText();
    }

    public void UpdateText() {
        TextMeshPro tmp = transform.GetChild(0).GetComponent<TextMeshPro>();
        tmp.text = text;
        tmp.fontSize = size;
    }
    private void Update() {
        GameObject player = GameObject.Find("Player");
        if (Vector3.Distance(player.transform.position, transform.position) <= distance)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.LookAt(Camera.main.transform);
        } else {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
