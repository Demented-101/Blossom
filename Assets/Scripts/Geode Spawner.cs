using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeodeSpawner : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private GameObject geode;
    [SerializeField] private Material geodeMaterial;
    [SerializeField] private string geodeName;

    [Header("Position")]
    [SerializeField] private float rangeX;
    [SerializeField] private float rangeZ;
    [SerializeField] private float rangeY;
    [SerializeField] private Vector3 offset;

    [Header("Scale")]
    [SerializeField] private float scaleMin;
    [SerializeField] private float scaleMax;

    public void Run()
    {
        Vector3 geode_offset = transform.position + offset;
        for (int i = 0; i < count; i++)
        {
            // create new flower and add it as child
            GameObject newGeode = Instantiate(geode);
            newGeode.transform.parent = transform;
            newGeode.GetComponent<Geode>().SetGeodeMaterial(geodeMaterial);
            newGeode.GetComponent<Geode>().name = geodeName;

            // position & rotation
            newGeode.transform.position = new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), Random.Range(-rangeZ, rangeZ)) + geode_offset;
            newGeode.transform.Rotate(Vector3.up, Random.Range(-180, 180));

            // scale 
            float geodeScale = Random.Range(scaleMin, scaleMax);
            newGeode.transform.localScale = new Vector3(geodeScale, geodeScale, geodeScale);
        }
    }
}
