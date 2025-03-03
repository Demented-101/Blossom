using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;

    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    AutoExposure exposure;

    // Start is called before the first frame update
    void Start()
    {
        brightness.TryGetSettings(out exposure);
        LoadBrightness();
        AdjustBrightness(brightnessSlider.value);
    }

    // Update is called once per frame
    public void AdjustBrightness(float value)
    {
        float bright = brightnessSlider.value;
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = 0.5f;
        }
        PlayerPrefs.SetFloat("Brightness", bright);
    }
    private void LoadBrightness()
    {
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
    }
}
