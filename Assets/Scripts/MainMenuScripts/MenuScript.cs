using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text usernameText;

    [SerializeField]
    private TMP_Text highscoreText;
    private void Start()
    {
        StartCoroutine(
           UserApiManager.instance
           .GetUserData(
               UpdateUI));
    }
    private void UpdateUI(
        UserGameData profile)
    {
        usernameText.text =
            
            profile.userName;

        highscoreText.text =
            "Highscore: " +
            profile.highScore;
    }
    public void PlayGame()
    {
        //Console.Write("loading");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public void LogoutGame()
    {
        PlayerPrefs.DeleteKey("token");

        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
