using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class AuthApiMaanger : MonoBehaviour
{
    public static AuthApiMaanger instance;
    private string baseUrl = "https://gamebackend-yw5p.onrender.com/api/Auth";
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    public IEnumerator Register(RegisterRequest registerRequest,System.Action<bool,string> callback)
    {
        string json=JsonUtility.ToJson(registerRequest);
        byte[] bodyraw=Encoding.UTF8.GetBytes(json);
        UnityWebRequest webRequest=new UnityWebRequest(baseUrl+"/register","POST");
        webRequest.uploadHandler = new UploadHandlerRaw(bodyraw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type","application/json");
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            callback(true, "");
        }
        else
        {
            callback(false, webRequest.downloadHandler.text);
            //Debug.Log(webRequest.downloadHandler.text);
        }


    }
    public IEnumerator Login(LoginRequest loginRequest,System.Action<bool,string> callback)
    {
        string json=JsonUtility.ToJson(loginRequest);
        byte[] bodyRaw=Encoding.UTF8.GetBytes(json);
        UnityWebRequest webRequest = new UnityWebRequest(baseUrl + "/login", "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler= new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type","application/json");
        yield return webRequest.SendWebRequest();
        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            AuthResponse authResponse=JsonUtility.FromJson<AuthResponse>(webRequest.downloadHandler.text);
            PlayerPrefs.SetString("token",authResponse.token);
            callback(true,"");
        }
        else
        {
            callback(false,webRequest.downloadHandler.text);
        }
    }
    
}
