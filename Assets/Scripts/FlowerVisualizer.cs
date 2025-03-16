using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlowerVisualizer : MonoBehaviour
{
    private GameObject currentFlower;
    public void SetFlower(int index)
    {
        if (currentFlower != null)
        {
            currentFlower.SetActive(false);
        }

        currentFlower = transform.GetChild(index).gameObject;
        currentFlower.SetActive(true);
    }


    public void ResetMaterial()
    {
        if (currentFlower != null){ currentFlower.GetComponent<Flower>().ResetMaterial(); }
    }
    public void SetMaterial(Material material)
    {
        if (currentFlower != null) { currentFlower.GetComponent<Flower>().SetMaterial(material, false); }
    }
    public void SetMaterialIncStem(Material material)
    {
        if (currentFlower != null) { currentFlower.GetComponent<Flower>().SetMaterial(material, true); }
    }

}
