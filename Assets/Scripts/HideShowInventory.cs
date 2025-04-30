using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowInventory : MonoBehaviour
{
    public GameObject theInventory; 

    public void HideInventory()
    {
        theInventory.SetActive(false); 
    }

    public void ShowInventory()
    {
        theInventory.SetActive(true); 
    }
}
