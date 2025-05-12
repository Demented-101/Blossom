using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CooldownButton : MonoBehaviour
{
    public Button cooldownButton;
    public TMP_Text cooldownText;

    private float cooldownDuration = 300f; // 5 minutes in seconds
    private DateTime lastPressedTime;

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
        }
        else
        {
            cooldownButton.interactable = true;
            cooldownText.text = "Press Me!";
        }
    }

    void OnButtonPressed()
    {
        lastPressedTime = DateTime.UtcNow;
        PlayerPrefs.SetString("LastButtonPress", lastPressedTime.ToBinary().ToString());
        PlayerPrefs.Save();

        Debug.Log("Button Pressed!");
        // Put your button logic here (e.g., reward, action, etc.)
    }
}
