using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private GameObject flower;

    [Header("Position")]
    [SerializeField] private float rangeX;
    [SerializeField] private float rangeZ;
    [SerializeField] private float rangeY;
    [SerializeField] private Vector3 offset;

    [Header("Scale")]
    [SerializeField] private float scaleMin;
    [SerializeField] private float scaleMax;

    void Start() {
        Vector3 flower_offset = transform.position + offset;
        for(int i = 0; i < count; i++) {
            // create new flower and add it as child
            GameObject newflower = Instantiate(flower);
            newflower.transform.parent = transform;

            // position & rotation
            newflower.transform.position = new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), Random.Range(-rangeZ, rangeZ)) + flower_offset;
            newflower.transform.Rotate(Vector3.up, Random.Range(-180, 180));

            // scale 
            float flowerScale = Random.Range(scaleMin, scaleMax);
            newflower.transform.localScale = new Vector3(flowerScale, flowerScale, flowerScale);
        }
    }

}
