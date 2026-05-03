using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    private void Awake()
    {
        if(instance == null)
        instance = this; 
    }
    // Start is called before the first frame update
    public void RestartGame()
    {
        Invoke("RestartAfterTime", 2f);
    }
    public void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
