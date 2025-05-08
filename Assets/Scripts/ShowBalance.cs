using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowBalance : MonoBehaviour
{
    SaveData saveData;
    SellFlowers sellFlowers; 
    public TMP_Text profitText; 

    void Start()
    {
        // Check if profitText is assigne
        if (profitText == null)
        {
            profitText = GetComponent<TMP_Text>();
            if (profitText == null)
            {
                Debug.LogError("ShowBalance: profitText is not assigned");
                return; 
            }
        }

        // Ensure saveData is initialize
        if (saveData == null)
        {
            Debug.LogWarning("ShowBalance: saveData is not assigned. Creating a new SaveData instance.");
            saveData = new SaveData(); 
            saveData.loadBasics(); 
        }

    }


    void Update()
    {
        profitText.text = "Profit: " + sellFlowers.profit;

    }
  
}
