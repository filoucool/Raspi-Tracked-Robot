using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ToVuforia()
    {
        SceneManager.LoadScene("Vuforia");
    }
    public void ToRemote()
    {
        SceneManager.LoadScene("Controller");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}