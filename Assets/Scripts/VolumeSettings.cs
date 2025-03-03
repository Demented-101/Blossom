using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer MyMixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))

        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetMasterVolume();
            SetSFXVolume();
        }

    }
    public void SetMasterVolume()
    {
        float volume = MasterSlider.value;
        MyMixer.SetFloat("Master", Mathf.Log10(volume) * 25);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        MyMixer.SetFloat("Music", Mathf.Log10(volume)*25);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        MyMixer.SetFloat("SFX", Mathf.Log10(volume) * 25);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        MusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetMasterVolume();
        SetSFXVolume();
    }
}
