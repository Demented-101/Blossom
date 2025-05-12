using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellFlowers : MonoBehaviour
{
    public Button toggleButton;
    public Button closeButton;
     
    public Button sellButton; 

    public Sprite menuSprite;  
    public Sprite crossSprite; 


    public static bool isSellButtonPressed; 
    

    public GameObject theBackground; 

    [HideInInspector]
    public GameObject[] lily, daisy, foxglove, orchid, sweetpea, tulip, rose, nightshade; 

    private bool isMenuOpen = false;
    private Image buttonImage;
    private Image closeImage;

    

    public TMP_Text noteText; 
    public TMP_Text countdown; 
    public TMP_Text inStock; 
    public TMP_Text numberSold; 
    public TMP_Text profitText; 
    public TMP_Text tulipStock, foxgloveStock, nightshadeStock, roseStock, daisyStock, lotvStock, orchidStock, sweetpeaStock; 
    public TMP_Text tulipSold, foxgloveSold, nightshadeSold, roseSold, daisySold, lotvSold, orchidSold, sweetpeaSold;

    public SaveData saveData;
    public int profit;

    void Start()
    {
        SaveData data = SaveManager.Load();
        profit = data.money;

        //Open button initialisation
        buttonImage = toggleButton.GetComponent<Image>();
        toggleButton.onClick.AddListener(ToggleMenu);

        //Close button initilisaition
        closeImage = closeButton.GetComponent<Image>();
        closeButton.onClick.AddListener(ToggleMenu);
        closeButton.gameObject.SetActive(false);

        //Sell button
        sellButton.gameObject.SetActive(false);
        countdown.gameObject.SetActive(false); 

        isSellButtonPressed = false;
        profit = saveData.money;
        FlowerCounter(); 
        UpdateUI();
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (isMenuOpen)
        {
            //enable all pop up menu elements 
            buttonImage.sprite = crossSprite;
            inStock.enabled = true;
            numberSold.enabled = true;
            theBackground.SetActive(true); 
            countdown.gameObject.SetActive(true); 

            tulipStock.enabled = true; 
            foxgloveStock.enabled = true; 
            nightshadeStock.enabled = true; 
            roseStock.enabled = true; 
            daisyStock.enabled = true; 
            lotvStock.enabled = true; 
            orchidStock.enabled = true; 
            sweetpeaStock.enabled = true; 

            tulipSold.enabled = true; 
            foxgloveSold.enabled = true; 
            nightshadeSold.enabled = true; 
            roseSold.enabled = true; 
            daisySold.enabled = true; 
            lotvSold.enabled = true; 
            orchidSold.enabled = true; 
            sweetpeaSold.enabled = true; 

            noteText.enabled = true; 
            sellButton.enabled = true; 
            profitText.enabled = true;

            toggleButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);
            sellButton.gameObject.SetActive(true);
            Debug.Log("Enabled");
        }
        else
        {
            //disable all pop up menu elements 
            buttonImage.sprite = menuSprite;
            inStock.enabled = false;
            numberSold.enabled = false;
            theBackground.SetActive(false); 
            countdown.gameObject.SetActive(false); 

            tulipStock.enabled = false; 
            foxgloveStock.enabled = false; 
            nightshadeStock.enabled = false; 
            roseStock.enabled = false; 
            daisyStock.enabled = false; 
            lotvStock.enabled = false; 
            orchidStock.enabled = false; 
            sweetpeaStock.enabled = false; 

            tulipSold.enabled = false; 
            foxgloveSold.enabled = false; 
            nightshadeSold.enabled = false; 
            roseSold.enabled = false; 
            daisySold.enabled = false; 
            lotvSold.enabled = false; 
            orchidSold.enabled = false; 
            sweetpeaSold.enabled = false; 

            noteText.enabled = false; 
            sellButton.enabled = false; 
            profitText.enabled = false;

           toggleButton.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(false);
            sellButton.gameObject.SetActive(false);
            Debug.Log("Disabled");
        }
    }

    public void FlowerCounter()
    {
        //find all the flowers depending on their tags 
        lily = GameObject.FindGameObjectsWithTag("LilyOfTheValley");
        daisy = GameObject.FindGameObjectsWithTag("Daisy");
        foxglove = GameObject.FindGameObjectsWithTag("Foxglove");
        orchid = GameObject.FindGameObjectsWithTag("Orchid");
        sweetpea = GameObject.FindGameObjectsWithTag("Sweetpea");
        tulip = GameObject.FindGameObjectsWithTag("Tulip");
        rose = GameObject.FindGameObjectsWithTag("Rose");
        nightshade = GameObject.FindGameObjectsWithTag("Nightshade");


        int lilyCount = lily.Length;
        int daisyCount = daisy.Length;
        int foxgloveCount = foxglove.Length;
        int orchidCount = orchid.Length;
        int sweetpeaCount = sweetpea.Length;
        int tulipCount = tulip.Length;
        int roseCount = rose.Length;
        int nightshadeCount = nightshade.Length;

        lotvStock.text = "Lily Of The Valley's: " + lilyCount;
        daisyStock.text = "Daisies: " + daisyCount;
        foxgloveStock.text = "Foxgloves: " + foxgloveCount;
        orchidStock.text = "Orchids: " + orchidCount;
        sweetpeaStock.text = "Sweetpeas: " + sweetpeaCount;
        tulipStock.text = "Tulips: " + tulipCount;
        roseStock.text = "Roses: " + roseCount;
        nightshadeStock.text = "Nightshades: " + nightshadeCount;
    }

    public void SellButton()
    {
        int lilyRandomNumber = Random.Range(0, lily.Length); 
        int daisyRandomNumber = Random.Range(0, daisy.Length); 
        int foxgloveRandomNumber = Random.Range(0, foxglove.Length); 
        int orchidRandomNumber = Random.Range(0, orchid.Length); 
        int sweetpeaRandomNumber = Random.Range(0, sweetpea.Length); 
        int tulipRandomNumber = Random.Range(0, tulip.Length); 
        int roseRandomNumber = Random.Range(0, rose.Length); 
        int nightshadeRandomNumber = Random.Range(0, nightshade.Length); 

        lotvStock.text = "Lily Of The Valley's: " + (lily.Length - lilyRandomNumber);
        daisyStock.text = "Daisies: " + (daisy.Length - daisyRandomNumber);
        foxgloveStock.text = "Foxgloves: " + (foxglove.Length - foxgloveRandomNumber);
        orchidStock.text = "Orchids: " + (orchid.Length - orchidRandomNumber);
        sweetpeaStock.text = "Sweetpeas: " + (sweetpea.Length - sweetpeaRandomNumber);
        tulipStock.text = "Tulips: " + (tulip.Length - tulipRandomNumber);
        roseStock.text = "Roses: " + (rose.Length - roseRandomNumber);
        nightshadeStock.text = "Nightshades: " + (nightshade.Length - nightshadeRandomNumber);

        lotvSold.text = "Lily Of The Valley's: " + lilyRandomNumber;
        daisySold.text = "Daisies: " + daisyRandomNumber;
        foxgloveSold.text = "Foxgloves: " + foxgloveRandomNumber;
        orchidSold.text = "Orchids: " + orchidRandomNumber;
        sweetpeaSold.text = "Sweetpeas: " + sweetpeaRandomNumber;
        tulipSold.text = "Tulips: " + tulipRandomNumber;
        roseSold.text = "Roses: " + roseRandomNumber;
        nightshadeSold.text = "Nightshades: " + nightshadeRandomNumber;
        profitText.text = "Profit: " + saveData.money;

        sellButton.gameObject.SetActive(false); 
        isSellButtonPressed = true; 
        noteText.enabled = false; 
        int flowerTotal = (lilyRandomNumber + daisyRandomNumber + foxgloveRandomNumber + orchidRandomNumber + sweetpeaRandomNumber
                        + tulipRandomNumber + roseRandomNumber + nightshadeRandomNumber); 

        
        //remove number of lotvs from scene 
        for(int i =0;i<lilyRandomNumber;i++)
        {
            lily[i].SetActive(false); 
        }

        //remove number of daisies from scene 
        for(int i =0;i<daisyRandomNumber;i++)
        {
            daisy[i].SetActive(false); 
        }

        //remove number of foxgloves from scene 
        for(int i =0;i<foxgloveRandomNumber;i++)
        {
            foxglove[i].SetActive(false); 
        }

        //remove number of orchids from scene 
        for(int i =0;i<orchidRandomNumber;i++)
        {
            orchid[i].SetActive(false); 
        }

        //remove number of sweetpeas from scene 
        for(int i =0;i<sweetpeaRandomNumber;i++)
        {
            sweetpea[i].SetActive(false); 
        }

        //remove number of tulips from scene 
        for(int i =0;i<tulipRandomNumber;i++)
        {
            tulip[i].SetActive(false); 
        }

        //remove number of roses from scene 
        for(int i =0;i<roseRandomNumber;i++)
        {
            rose[i].SetActive(false); 
        }

        //remove number of nightshades from scene 
        for(int i =0;i<nightshadeRandomNumber;i++)
        {
            nightshade[i].SetActive(false); 
        }

       
        profit = profit + flowerTotal * 3;
        
        //updating player data
        saveData.money = profit;
        PlayerData.money = profit;
        SaveManager.Save();
        Debug.Log("Sold! New balance " + profit);
        Debug.Log(saveData.money);
       

    }
}
