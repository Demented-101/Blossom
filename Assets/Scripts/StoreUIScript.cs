using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StoreUIScript : MonoBehaviour
{
    public GameObject profitTextObj;
    public GameObject dayTextObj;

    public GameObject flowerNametext;
    public GameObject flowerSpectext;
    public GameObject flowerColourtext;
    public GameObject flowerGeodetext;
    public GameObject flowerPricetext;


    public void SelectFlower(string name)
    {
        flowerNametext.GetComponent<TextMeshPro>().text = name;
    }
}
