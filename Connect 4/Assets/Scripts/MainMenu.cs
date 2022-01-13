using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitButtonClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void EasyButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void MultiplayerButtonClicked()
    {
        SceneManager.LoadScene("MultiplayerLoading");
    }

    public void CustomButtonClicked()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
}