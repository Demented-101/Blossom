using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geode : MonoBehaviour
{
    [SerializeField] private GameObject[] crystals;
    public string name;

    public void SetGeodeMaterial(Material material)
    {
        foreach(GameObject obj in crystals)
        {
            obj.GetComponent<MeshRenderer>().material = material;
        }
    }
}
