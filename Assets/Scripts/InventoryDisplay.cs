using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public PlayerData playerData; 
    public Flower theFlower; 

    public TextMeshProUGUI tulipNumber, roseNumber, orchidNumber, foxgloveNumber, daisyNumber, nightshadeNumber, lotvNumber, sweetpeaNumber;

    void Update()
    {
        int tulipNum = playerData.GetItemAmount("Tulip"); 
        int roseNum = playerData.GetItemAmount("Rose"); 
        int orchidNum = playerData.GetItemAmount("Orchid"); 
        int foxgloveNum = playerData.GetItemAmount("Foxglove"); 
        int lotvNum = playerData.GetItemAmount("LilyOfTheValley"); 
        int daisyNum = playerData.GetItemAmount("Daisy"); 
        int nightshadeNum = playerData.GetItemAmount("Nightshade"); 
        int sweetpeaNum = playerData.GetItemAmount("Sweetpea"); 

        tulipNumber.text = tulipNum.ToString(); 
        roseNumber.text = roseNum.ToString(); 
        orchidNumber.text = orchidNum.ToString(); 
        foxgloveNumber.text = foxgloveNum.ToString(); 
        lotvNumber.text = lotvNum.ToString(); 
        daisyNumber.text = daisyNum.ToString(); 
        nightshadeNumber.text = nightshadeNum.ToString();
        sweetpeaNumber.text = sweetpeaNum.ToString();  
    }
}
