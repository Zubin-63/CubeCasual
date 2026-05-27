using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_InputField emailInput;

    [SerializeField]
    private TMP_InputField passwordInput;

    [SerializeField]
    private TMP_Text errorText;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("token"))
        {
            SceneManager.LoadScene(
                "MainMenu");
        }
        
    }
    public void LoginGame()
    {
        errorText.text = "";

        LoginRequest request =
            new LoginRequest();

        request.email =
            emailInput.text;

        request.password =
            passwordInput.text;

        StartCoroutine(
            AuthApiMaanger.instance.Login(
                request,
                OnLoginResponse));
        
    }
    private void OnLoginResponse(
        bool success,
        string message)
    {
        if (success)
        {
            Debug.Log(PlayerPrefs.GetString("token"));
            SceneManager.LoadScene(
                "MainMenu");
        }
        else
        {
            
            errorText.text =
                message;
        }
    }
    public void Register()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }

}
