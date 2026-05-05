using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Console.Write("loading");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
