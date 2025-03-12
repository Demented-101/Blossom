using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if(PlayerPrefs.GetInt("loadSaved") == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
        }
        else
        {
            SceneManager.LoadScene("Garden");
        }

    }
    public void MainScene()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("loadSaved", 1);
        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("UI");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
