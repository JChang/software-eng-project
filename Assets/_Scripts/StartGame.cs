using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public void OnPlayButton() 
    {
        SceneManager.LoadScene("LostLarry");
    }

    public void OnQuitButton() 
    {
        Application.Quit();
    }
}