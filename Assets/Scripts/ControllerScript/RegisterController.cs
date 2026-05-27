using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_InputField usernameInput;

    [SerializeField]
    private TMP_InputField emailInput;

    [SerializeField]
    private TMP_InputField passwordInput;

    [SerializeField]
    private TMP_InputField ageInput;

    [SerializeField]
    private TMP_Dropdown genderDropdown;

    [SerializeField]
    private TMP_Text errorText;
    public void BackToLogin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
    }
    public void Register()
    {
        errorText.text = "";

        RegisterRequest request =
            new RegisterRequest();

        request.username =
            usernameInput.text;

        request.email =
            emailInput.text;

        request.password =
            passwordInput.text;

        request.age =
            int.Parse(ageInput.text);

        request.gender =
            genderDropdown.options[
                genderDropdown.value
            ].text;

        StartCoroutine(
            AuthApiMaanger.instance.Register(
                request,
                OnRegisterResponse));

    }
    private void OnRegisterResponse(bool sucess,string message)
    {
        if (sucess)
        {
            BackToLogin();
        }
        else
        {
            errorText.text = message;
        }
    }
}
