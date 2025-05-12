using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;

public class CooldownButton : MonoBehaviour
{
    public Button cooldownButton;
    public TMP_Text cooldownText;
    public TMP_Text dayText; 

    private float cooldownDuration = 2f; // 5 minutes in seconds
    private DateTime lastPressedTime;

    private bool cooldownEnded = false; // Flag to track cooldown end

    void Start()
    {
        if (cooldownButton == null || cooldownText == null)
        {
            Debug.LogError("Assign the Button and Text in the inspector.");
            return;
        }

        // Load saved time if available
        if (PlayerPrefs.HasKey("LastButtonPress"))
        {
            long binaryTime = Convert.ToInt64(PlayerPrefs.GetString("LastButtonPress"));
            lastPressedTime = DateTime.FromBinary(binaryTime);
        }
        else
        {
            lastPressedTime = DateTime.MinValue;
        }

        cooldownButton.onClick.AddListener(OnButtonPressed);
    }

    void Update()
    {
        TimeSpan timeSinceLastPress = DateTime.UtcNow - lastPressedTime;
        float secondsRemaining = (float)(cooldownDuration - timeSinceLastPress.TotalSeconds);

        if (secondsRemaining > 0)
        {
            cooldownButton.interactable = false;
            cooldownText.text = $"Available in {Mathf.Ceil(secondsRemaining)}s";
            cooldownEnded = false; // Reset flag during cooldown
        }
        else
        {
            if (!cooldownEnded)
            {
                cooldownButton.interactable = true;
                dayText.text = "Day - " + (int.Parse(dayText.text.Substring(6) + 1).ToString());
                cooldownEnded = true;
            }
        }
    }

    void OnButtonPressed()
    {
        lastPressedTime = DateTime.UtcNow;
        PlayerPrefs.SetString("LastButtonPress", lastPressedTime.ToBinary().ToString());
        PlayerPrefs.Save();

        cooldownEnded = false; // Reset flag for the new cooldown
        Debug.Log("Button Pressed!");
        // Your button logic here
    }
}
