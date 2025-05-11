using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowBalance : MonoBehaviour
{
    SellFlowers sellFlowers;
    SaveData data;
    public TMP_Text profitText;
    private int money;

    void Start()
    {
        SaveData data = SaveManager.Load();
        money = data.money;
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


    }


    void Update()
    {
        SaveData data = SaveManager.Load();
        profitText.text = "Profit - " + data.money;

    }
  
}
