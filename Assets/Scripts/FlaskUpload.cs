using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class FlaskUpload : MonoBehaviour
{
    public static FlaskUpload instance = null;
    public bool isLoaded = false;
    public bool isToxic = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public IEnumerator PostRequest(Comment comment)
    {
        
        isLoaded = false;
        string jsonString = JsonUtility.ToJson(comment);

        var request = new UnityWebRequest("https://comment-analysis.herokuapp.com/results", "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonString);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error + ", 에러 코드: " + request.responseCode.ToString());
        }
        else
        {
            Debug.Log("Form upload complete!, 결과: " + request.downloadHandler.text);
            if(request.downloadHandler.text.Substring(0,1) == "0")                                                                       
            {
                isToxic = false;
            }
            else if(request.downloadHandler.text.Substring(0, 1) == "1")
            {
                isToxic = true;
            }
            else
            {// Error
                Debug.Log("NETWORK ERROR");
            }
            isLoaded = true;
        }
    }
}