using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class UserApiManager : MonoBehaviour
{
    public static UserApiManager instance;
    private string baseUrl = "https://gamebackend-yw5p.onrender.com/api/UserGame";
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator GetUserData(System.Action<UserGameData> callback)
    {
        string token = PlayerPrefs.GetString("token");
        UnityWebRequest webRequest = UnityWebRequest.Get(baseUrl + "/profile");
        webRequest.SetRequestHeader(
            "Authorization",
            "Bearer " + token);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            UserGameData gameData = JsonUtility.FromJson<UserGameData>(webRequest.downloadHandler.text);
            callback(gameData);
        }
        else
        {
            Debug.LogError(
        "Error: " +
        webRequest.responseCode);

            Debug.LogError(
                webRequest.error);

            Debug.LogError(
                webRequest.downloadHandler.text);
        }

    }
    // Start is called before the first frame update
    
}
