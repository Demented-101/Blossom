using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI blossomText; 
    public TextMeshProUGUI instructionsLabel;
    public TextMeshProUGUI instructionsParagraph; 
    public GameObject backButton; 
    public GameObject settingsButton; 
    public GameObject playButton; 
    public GameObject rulesButton; 

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);  
    }

    public void HideBlossomText()
    {
        blossomText.enabled = false;
    }

    public void ShowBlossomText()
    {
        blossomText.enabled = true;
    }

    public void SettingsPlayRulesDisable()
    {
        settingsButton.SetActive(false); 
        playButton.SetActive(false); 
        rulesButton.SetActive(false); 
        backButton.SetActive(false); 

    }

    public void SettingsPlayRulesEnable()
    {
        settingsButton.SetActive(true); 
        playButton.SetActive(true); 
        rulesButton.SetActive(true); 
        backButton.SetActive(false); 

    }

    public void EnableBackButton()
    {
        backButton.SetActive(true); 
    }

    public void HideBackButton()
    {
        backButton.SetActive(false); 
    }

    public void HideInstructions()
    {
        instructionsLabel.enabled = false;
        instructionsParagraph.enabled = false; 
    }

    public void ShowInstructions()
    {
        instructionsLabel.enabled = true;
        instructionsParagraph.enabled = true; 
    }
}
