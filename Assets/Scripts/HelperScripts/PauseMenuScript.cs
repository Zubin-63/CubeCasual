using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool isPaused = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenuRedirect()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
